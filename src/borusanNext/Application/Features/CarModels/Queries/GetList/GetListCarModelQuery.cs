using Application.Features.CarModels.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CarModels.Constants.CarModelsOperationClaims;

namespace Application.Features.CarModels.Queries.GetList;

public class GetListCarModelQuery : IRequest<GetListResponse<GetListCarModelListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListCarModelQueryHandler : IRequestHandler<GetListCarModelQuery, GetListResponse<GetListCarModelListItemDto>>
    {
        private readonly ICarModelRepository _carModelRepository;
        private readonly IMapper _mapper;

        public GetListCarModelQueryHandler(ICarModelRepository carModelRepository, IMapper mapper)
        {
            _carModelRepository = carModelRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCarModelListItemDto>> Handle(GetListCarModelQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CarModel> carModels = await _carModelRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCarModelListItemDto> response = _mapper.Map<GetListResponse<GetListCarModelListItemDto>>(carModels);
            return response;
        }
    }
}