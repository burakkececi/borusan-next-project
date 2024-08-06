using Application.Features.Engines.Constants;
using Application.Features.Engines.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Engines.Constants.EnginesOperationClaims;

namespace Application.Features.Engines.Commands.Update;

public class UpdateEngineCommand : IRequest<UpdatedEngineResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string EngineNo { get; set; }
    public required int EngineCapacity { get; set; }
    public required int MotorPower { get; set; }
    public required int MaximumTorque { get; set; }
    public required double Acceleration { get; set; }
    public required int MaximumSpeed { get; set; }
    public required int FuelTankVolume { get; set; }
    public required Guid FuelTypeId { get; set; }
    public double OutOfTownConsumptionRate { get; set; }
    public double UrbanConsumptionRate { get; set; }
    public double AverageConsumptionRate { get; set; }

    public string[] Roles => [Admin, Write, EnginesOperationClaims.Update];

    public class UpdateEngineCommandHandler : IRequestHandler<UpdateEngineCommand, UpdatedEngineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEngineRepository _engineRepository;
        private readonly EngineBusinessRules _engineBusinessRules;

        public UpdateEngineCommandHandler(IMapper mapper, IEngineRepository engineRepository,
                                         EngineBusinessRules engineBusinessRules)
        {
            _mapper = mapper;
            _engineRepository = engineRepository;
            _engineBusinessRules = engineBusinessRules;
        }

        public async Task<UpdatedEngineResponse> Handle(UpdateEngineCommand request, CancellationToken cancellationToken)
        {
            Engine? engine = await _engineRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _engineBusinessRules.EngineShouldExistWhenSelected(engine);
            engine = _mapper.Map(request, engine);

            await _engineRepository.UpdateAsync(engine!);

            UpdatedEngineResponse response = _mapper.Map<UpdatedEngineResponse>(engine);
            return response;
        }
    }
}