using Application.Features.CarColors.Queries.GetDynamic;
using Application.Features.CarModels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.CarModels.Constants.CarModelsOperationClaims;


namespace Application.Features.CarModels.Queries.GetDynamic;
public class GetDynamicCarModelsQuery : IRequest<GetListResponse<GetDynamicCarModelsResponse>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetDynamicCarModelsQueryHandler : IRequestHandler<GetDynamicCarModelsQuery, GetListResponse<GetDynamicCarModelsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICarModelRepository _carModelRepository;
        private readonly CarModelBusinessRules _carModelBusinessRules;

        public GetDynamicCarModelsQueryHandler(IMapper mapper, ICarModelRepository carModelRepository, CarModelBusinessRules carModelBusinessRules)
        {
            _mapper = mapper;
            _carModelRepository = carModelRepository;
            _carModelBusinessRules = carModelBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicCarModelsResponse>> Handle(GetDynamicCarModelsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CarModel> carModel = await _carModelRepository.GetListByDynamicAsync(
               dynamic: request.DynamicQuery,
               include: i => i.Include(c => c.Brand),
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize,
               cancellationToken: cancellationToken);


            GetListResponse<GetDynamicCarModelsResponse> response = _mapper.Map<GetListResponse<GetDynamicCarModelsResponse>>(carModel);
            return response;
        }
    }
}
