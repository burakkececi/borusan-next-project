using Application.Features.ExpertizeResults.Queries.GetDynamic;
using Application.Features.FuelTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.FuelTypes.Constants.FuelTypesOperationClaims;


namespace Application.Features.FuelTypes.Queries.GetDynamic;
public class GetDynamicFuelTypesQuery:IRequest<GetListResponse<GetDynamicFuelTypeResponse>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetDynamicFuelTypesQueryHandler : IRequestHandler<GetDynamicFuelTypesQuery, GetListResponse<GetDynamicFuelTypeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IFuelTypeRepository _fuelRepository;
        private readonly FuelTypeBusinessRules _fuelTypeBusinessRules;

        public GetDynamicFuelTypesQueryHandler(IMapper mapper, IFuelTypeRepository fuelRepository, FuelTypeBusinessRules fuelTypeBusinessRules)
        {
            _mapper = mapper;
            _fuelRepository = fuelRepository;
            _fuelTypeBusinessRules = fuelTypeBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicFuelTypeResponse>> Handle(GetDynamicFuelTypesQuery request, CancellationToken cancellationToken)
        {
            IPaginate<FuelType> fuelType = await _fuelRepository.GetListByDynamicAsync(
              dynamic: request.DynamicQuery,
              index: request.PageRequest.PageIndex,
              size: request.PageRequest.PageSize,
              cancellationToken: cancellationToken);


            GetListResponse<GetDynamicFuelTypeResponse> response = _mapper.Map<GetListResponse<GetDynamicFuelTypeResponse>>(fuelType);
            return response;
        }
    }
}
