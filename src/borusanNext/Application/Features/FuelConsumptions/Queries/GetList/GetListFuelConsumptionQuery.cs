using Application.Features.FuelConsumptions.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.FuelConsumptions.Constants.FuelConsumptionsOperationClaims;

namespace Application.Features.FuelConsumptions.Queries.GetList;

public class GetListFuelConsumptionQuery : IRequest<GetListResponse<GetListFuelConsumptionListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListFuelConsumptionQueryHandler : IRequestHandler<GetListFuelConsumptionQuery, GetListResponse<GetListFuelConsumptionListItemDto>>
    {
        private readonly IFuelConsumptionRepository _fuelConsumptionRepository;
        private readonly IMapper _mapper;

        public GetListFuelConsumptionQueryHandler(IFuelConsumptionRepository fuelConsumptionRepository, IMapper mapper)
        {
            _fuelConsumptionRepository = fuelConsumptionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFuelConsumptionListItemDto>> Handle(GetListFuelConsumptionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<FuelConsumption> fuelConsumptions = await _fuelConsumptionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFuelConsumptionListItemDto> response = _mapper.Map<GetListResponse<GetListFuelConsumptionListItemDto>>(fuelConsumptions);
            return response;
        }
    }
}