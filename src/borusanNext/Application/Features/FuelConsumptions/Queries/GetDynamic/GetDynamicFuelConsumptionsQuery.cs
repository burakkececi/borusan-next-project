using Application.Features.ChassisParts.Queries.GetDynamic;
using Application.Features.FuelConsumptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FuelConsumptions.Queries.GetDynamic;
public class GetDynamicFuelConsumptionsQuery:IRequest<GetListResponse<GetDynamicFuelConsumptionResponse>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public class GetDynamicFuelConsumptionsQueryHandler : IRequestHandler<GetDynamicFuelConsumptionsQuery, GetListResponse<GetDynamicFuelConsumptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IFuelConsumptionRepository _fuelConsumptionRepository;
        private readonly FuelConsumptionBusinessRules _fuelConsumptionBusinessRules;

        public GetDynamicFuelConsumptionsQueryHandler(IMapper mapper, IFuelConsumptionRepository fuelConsumptionRepository, FuelConsumptionBusinessRules fuelConsumptionBusinessRules)
        {
            _mapper = mapper;
            _fuelConsumptionRepository = fuelConsumptionRepository;
            _fuelConsumptionBusinessRules = fuelConsumptionBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicFuelConsumptionResponse>> Handle(GetDynamicFuelConsumptionsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<FuelConsumption> fuelConsumption = await _fuelConsumptionRepository.GetListByDynamicAsync(
              dynamic: request.DynamicQuery,
              index: request.PageRequest.PageIndex,
              size: request.PageRequest.PageSize,
              cancellationToken: cancellationToken);


            GetListResponse<GetDynamicFuelConsumptionResponse> response = _mapper.Map<GetListResponse<GetDynamicFuelConsumptionResponse>>(fuelConsumption);
            return response;
        }
    }
}
