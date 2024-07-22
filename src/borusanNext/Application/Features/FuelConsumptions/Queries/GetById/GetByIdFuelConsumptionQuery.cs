using Application.Features.FuelConsumptions.Constants;
using Application.Features.FuelConsumptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FuelConsumptions.Constants.FuelConsumptionsOperationClaims;

namespace Application.Features.FuelConsumptions.Queries.GetById;

public class GetByIdFuelConsumptionQuery : IRequest<GetByIdFuelConsumptionResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdFuelConsumptionQueryHandler : IRequestHandler<GetByIdFuelConsumptionQuery, GetByIdFuelConsumptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFuelConsumptionRepository _fuelConsumptionRepository;
        private readonly FuelConsumptionBusinessRules _fuelConsumptionBusinessRules;

        public GetByIdFuelConsumptionQueryHandler(IMapper mapper, IFuelConsumptionRepository fuelConsumptionRepository, FuelConsumptionBusinessRules fuelConsumptionBusinessRules)
        {
            _mapper = mapper;
            _fuelConsumptionRepository = fuelConsumptionRepository;
            _fuelConsumptionBusinessRules = fuelConsumptionBusinessRules;
        }

        public async Task<GetByIdFuelConsumptionResponse> Handle(GetByIdFuelConsumptionQuery request, CancellationToken cancellationToken)
        {
            FuelConsumption? fuelConsumption = await _fuelConsumptionRepository.GetAsync(predicate: fc => fc.Id == request.Id, cancellationToken: cancellationToken);
            await _fuelConsumptionBusinessRules.FuelConsumptionShouldExistWhenSelected(fuelConsumption);

            GetByIdFuelConsumptionResponse response = _mapper.Map<GetByIdFuelConsumptionResponse>(fuelConsumption);
            return response;
        }
    }
}