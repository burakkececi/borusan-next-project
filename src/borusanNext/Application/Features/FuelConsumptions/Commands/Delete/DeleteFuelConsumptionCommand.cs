using Application.Features.FuelConsumptions.Constants;
using Application.Features.FuelConsumptions.Constants;
using Application.Features.FuelConsumptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FuelConsumptions.Constants.FuelConsumptionsOperationClaims;

namespace Application.Features.FuelConsumptions.Commands.Delete;

public class DeleteFuelConsumptionCommand : IRequest<DeletedFuelConsumptionResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, FuelConsumptionsOperationClaims.Delete];

    public class DeleteFuelConsumptionCommandHandler : IRequestHandler<DeleteFuelConsumptionCommand, DeletedFuelConsumptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFuelConsumptionRepository _fuelConsumptionRepository;
        private readonly FuelConsumptionBusinessRules _fuelConsumptionBusinessRules;

        public DeleteFuelConsumptionCommandHandler(IMapper mapper, IFuelConsumptionRepository fuelConsumptionRepository,
                                         FuelConsumptionBusinessRules fuelConsumptionBusinessRules)
        {
            _mapper = mapper;
            _fuelConsumptionRepository = fuelConsumptionRepository;
            _fuelConsumptionBusinessRules = fuelConsumptionBusinessRules;
        }

        public async Task<DeletedFuelConsumptionResponse> Handle(DeleteFuelConsumptionCommand request, CancellationToken cancellationToken)
        {
            FuelConsumption? fuelConsumption = await _fuelConsumptionRepository.GetAsync(predicate: fc => fc.Id == request.Id, cancellationToken: cancellationToken);
            await _fuelConsumptionBusinessRules.FuelConsumptionShouldExistWhenSelected(fuelConsumption);

            await _fuelConsumptionRepository.DeleteAsync(fuelConsumption!);

            DeletedFuelConsumptionResponse response = _mapper.Map<DeletedFuelConsumptionResponse>(fuelConsumption);
            return response;
        }
    }
}