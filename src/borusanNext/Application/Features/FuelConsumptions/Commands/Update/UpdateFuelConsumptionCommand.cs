using Application.Features.FuelConsumptions.Constants;
using Application.Features.FuelConsumptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FuelConsumptions.Constants.FuelConsumptionsOperationClaims;

namespace Application.Features.FuelConsumptions.Commands.Update;

public class UpdateFuelConsumptionCommand : IRequest<UpdatedFuelConsumptionResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required double OutOfTown { get; set; }
    public required double Urban { get; set; }
    public required double Average { get; set; }

    public string[] Roles => [Admin, Write, FuelConsumptionsOperationClaims.Update];

    public class UpdateFuelConsumptionCommandHandler : IRequestHandler<UpdateFuelConsumptionCommand, UpdatedFuelConsumptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFuelConsumptionRepository _fuelConsumptionRepository;
        private readonly FuelConsumptionBusinessRules _fuelConsumptionBusinessRules;

        public UpdateFuelConsumptionCommandHandler(IMapper mapper, IFuelConsumptionRepository fuelConsumptionRepository,
                                         FuelConsumptionBusinessRules fuelConsumptionBusinessRules)
        {
            _mapper = mapper;
            _fuelConsumptionRepository = fuelConsumptionRepository;
            _fuelConsumptionBusinessRules = fuelConsumptionBusinessRules;
        }

        public async Task<UpdatedFuelConsumptionResponse> Handle(UpdateFuelConsumptionCommand request, CancellationToken cancellationToken)
        {
            FuelConsumption? fuelConsumption = await _fuelConsumptionRepository.GetAsync(predicate: fc => fc.Id == request.Id, cancellationToken: cancellationToken);
            await _fuelConsumptionBusinessRules.FuelConsumptionShouldExistWhenSelected(fuelConsumption);
            fuelConsumption = _mapper.Map(request, fuelConsumption);

            await _fuelConsumptionRepository.UpdateAsync(fuelConsumption!);

            UpdatedFuelConsumptionResponse response = _mapper.Map<UpdatedFuelConsumptionResponse>(fuelConsumption);
            return response;
        }
    }
}