using Application.Features.ChassisParts.Constants;
using Application.Features.ChassisParts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ChassisParts.Constants.ChassisPartsOperationClaims;

namespace Application.Features.ChassisParts.Commands.Update;

public class UpdateChassisPartCommand : IRequest<UpdatedChassisPartResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required bool IsRightChassisChanged { get; set; }
    public required bool IsLeftChassisChanged { get; set; }
    public required bool IsFrontPanelChanged { get; set; }
    public required bool IsBackPanelChanged { get; set; }

    public string[] Roles => [Admin, Write, ChassisPartsOperationClaims.Update];

    public class UpdateChassisPartCommandHandler : IRequestHandler<UpdateChassisPartCommand, UpdatedChassisPartResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChassisPartRepository _chassisPartRepository;
        private readonly ChassisPartBusinessRules _chassisPartBusinessRules;

        public UpdateChassisPartCommandHandler(IMapper mapper, IChassisPartRepository chassisPartRepository,
                                         ChassisPartBusinessRules chassisPartBusinessRules)
        {
            _mapper = mapper;
            _chassisPartRepository = chassisPartRepository;
            _chassisPartBusinessRules = chassisPartBusinessRules;
        }

        public async Task<UpdatedChassisPartResponse> Handle(UpdateChassisPartCommand request, CancellationToken cancellationToken)
        {
            ChassisPart? chassisPart = await _chassisPartRepository.GetAsync(predicate: cp => cp.Id == request.Id, cancellationToken: cancellationToken);
            await _chassisPartBusinessRules.ChassisPartShouldExistWhenSelected(chassisPart);
            chassisPart = _mapper.Map(request, chassisPart);

            await _chassisPartRepository.UpdateAsync(chassisPart!);

            UpdatedChassisPartResponse response = _mapper.Map<UpdatedChassisPartResponse>(chassisPart);
            return response;
        }
    }
}