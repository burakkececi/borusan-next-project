using Application.Features.FuelConsumptions.Constants;
using Application.Features.FuelConsumptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FuelConsumptions.Constants.FuelConsumptionsOperationClaims;

namespace Application.Features.FuelConsumptions.Commands.Create;

public class CreateFuelConsumptionCommand : IRequest<CreatedFuelConsumptionResponse>, ISecuredRequest
{
    public required double OutOfTown { get; set; }
    public required double Urban { get; set; }
    public required double Average { get; set; }

    public string[] Roles => [Admin, Write, FuelConsumptionsOperationClaims.Create];

    public class CreateFuelConsumptionCommandHandler : IRequestHandler<CreateFuelConsumptionCommand, CreatedFuelConsumptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFuelConsumptionRepository _fuelConsumptionRepository;
        private readonly FuelConsumptionBusinessRules _fuelConsumptionBusinessRules;

        public CreateFuelConsumptionCommandHandler(IMapper mapper, IFuelConsumptionRepository fuelConsumptionRepository,
                                         FuelConsumptionBusinessRules fuelConsumptionBusinessRules)
        {
            _mapper = mapper;
            _fuelConsumptionRepository = fuelConsumptionRepository;
            _fuelConsumptionBusinessRules = fuelConsumptionBusinessRules;
        }

        public async Task<CreatedFuelConsumptionResponse> Handle(CreateFuelConsumptionCommand request, CancellationToken cancellationToken)
        {
            FuelConsumption fuelConsumption = _mapper.Map<FuelConsumption>(request);

            await _fuelConsumptionRepository.AddAsync(fuelConsumption);

            CreatedFuelConsumptionResponse response = _mapper.Map<CreatedFuelConsumptionResponse>(fuelConsumption);
            return response;
        }
    }
}