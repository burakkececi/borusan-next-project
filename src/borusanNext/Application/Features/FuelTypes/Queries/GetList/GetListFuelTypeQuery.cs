using Application.Features.FuelTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.FuelTypes.Constants.FuelTypesOperationClaims;

namespace Application.Features.FuelTypes.Queries.GetList;

public class GetListFuelTypeQuery : IRequest<GetListResponse<GetListFuelTypeListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListFuelTypeQueryHandler : IRequestHandler<GetListFuelTypeQuery, GetListResponse<GetListFuelTypeListItemDto>>
    {
        private readonly IFuelTypeRepository _fuelTypeRepository;
        private readonly IMapper _mapper;

        public GetListFuelTypeQueryHandler(IFuelTypeRepository fuelTypeRepository, IMapper mapper)
        {
            _fuelTypeRepository = fuelTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFuelTypeListItemDto>> Handle(GetListFuelTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<FuelType> fuelTypes = await _fuelTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFuelTypeListItemDto> response = _mapper.Map<GetListResponse<GetListFuelTypeListItemDto>>(fuelTypes);
            return response;
        }
    }
}