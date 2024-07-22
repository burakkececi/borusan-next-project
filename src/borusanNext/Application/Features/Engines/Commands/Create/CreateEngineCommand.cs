using Application.Features.Engines.Constants;
using Application.Features.Engines.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Engines.Constants.EnginesOperationClaims;

namespace Application.Features.Engines.Commands.Create;

public class CreateEngineCommand : IRequest<CreatedEngineResponse>, ISecuredRequest
{
    public required string EngineNo { get; set; }
    public required int EngineCapacity { get; set; }
    public required int MotorPower { get; set; }
    public required int MaximumTorque { get; set; }
    public required double Acceleration { get; set; }
    public required int MaximumSpeed { get; set; }
    public required int FuelTankVolume { get; set; }
    public required Guid FuelTypeId { get; set; }
    public required Guid FuelConsumptionId { get; set; }

    public string[] Roles => [Admin, Write, EnginesOperationClaims.Create];

    public class CreateEngineCommandHandler : IRequestHandler<CreateEngineCommand, CreatedEngineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEngineRepository _engineRepository;
        private readonly EngineBusinessRules _engineBusinessRules;

        public CreateEngineCommandHandler(IMapper mapper, IEngineRepository engineRepository,
                                         EngineBusinessRules engineBusinessRules)
        {
            _mapper = mapper;
            _engineRepository = engineRepository;
            _engineBusinessRules = engineBusinessRules;
        }

        public async Task<CreatedEngineResponse> Handle(CreateEngineCommand request, CancellationToken cancellationToken)
        {
            Engine engine = _mapper.Map<Engine>(request);

            await _engineRepository.AddAsync(engine);

            CreatedEngineResponse response = _mapper.Map<CreatedEngineResponse>(engine);
            return response;
        }
    }
}