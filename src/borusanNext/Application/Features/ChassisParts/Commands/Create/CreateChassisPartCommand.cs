using Application.Features.ChassisParts.Constants;
using Application.Features.ChassisParts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ChassisParts.Constants.ChassisPartsOperationClaims;

namespace Application.Features.ChassisParts.Commands.Create;

public class CreateChassisPartCommand : IRequest<CreatedChassisPartResponse>, ISecuredRequest
{
    public required bool IsRightChassisChanged { get; set; }
    public required bool IsLeftChassisChanged { get; set; }
    public required bool IsFrontPanelChanged { get; set; }
    public required bool IsBackPanelChanged { get; set; }

    public string[] Roles => [Admin, Write, ChassisPartsOperationClaims.Create];

    public class CreateChassisPartCommandHandler : IRequestHandler<CreateChassisPartCommand, CreatedChassisPartResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChassisPartRepository _chassisPartRepository;
        private readonly ChassisPartBusinessRules _chassisPartBusinessRules;

        public CreateChassisPartCommandHandler(IMapper mapper, IChassisPartRepository chassisPartRepository,
                                         ChassisPartBusinessRules chassisPartBusinessRules)
        {
            _mapper = mapper;
            _chassisPartRepository = chassisPartRepository;
            _chassisPartBusinessRules = chassisPartBusinessRules;
        }

        public async Task<CreatedChassisPartResponse> Handle(CreateChassisPartCommand request, CancellationToken cancellationToken)
        {
            ChassisPart chassisPart = _mapper.Map<ChassisPart>(request);

            await _chassisPartRepository.AddAsync(chassisPart);

            CreatedChassisPartResponse response = _mapper.Map<CreatedChassisPartResponse>(chassisPart);
            return response;
        }
    }
}