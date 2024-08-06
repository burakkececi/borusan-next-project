using Application.Features.BodyShellParts.Constants;
using Application.Features.BodyShellParts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using Domain.Enums;
using static Application.Features.BodyShellParts.Constants.BodyShellPartsOperationClaims;

namespace Application.Features.BodyShellParts.Commands.Update;

public class UpdateBodyShellPartCommand : IRequest<UpdatedBodyShellPartResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required ExpertizeCondition LeftFrontFender { get; set; }
    public required ExpertizeCondition LeftFrontDoor { get; set; }
    public required ExpertizeCondition LeftRearDoor { get; set; }
    public required ExpertizeCondition LeftRearFender { get; set; }
    public required ExpertizeCondition RightFrontFender { get; set; }
    public required ExpertizeCondition RightFrontDoor { get; set; }
    public required ExpertizeCondition RightRearDoor { get; set; }
    public required ExpertizeCondition RightRearFender { get; set; }
    public required ExpertizeCondition Frontbumper { get; set; }
    public required ExpertizeCondition RearBumper { get; set; }
    public required ExpertizeCondition Bonnet { get; set; }
    public required ExpertizeCondition Ceiling { get; set; }
    public required ExpertizeCondition Luggage { get; set; }

    public string[] Roles => [Admin, Write, BodyShellPartsOperationClaims.Update];

    public class UpdateBodyShellPartCommandHandler : IRequestHandler<UpdateBodyShellPartCommand, UpdatedBodyShellPartResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBodyShellPartRepository _bodyShellPartRepository;
        private readonly BodyShellPartBusinessRules _bodyShellPartBusinessRules;

        public UpdateBodyShellPartCommandHandler(IMapper mapper, IBodyShellPartRepository bodyShellPartRepository,
                                         BodyShellPartBusinessRules bodyShellPartBusinessRules)
        {
            _mapper = mapper;
            _bodyShellPartRepository = bodyShellPartRepository;
            _bodyShellPartBusinessRules = bodyShellPartBusinessRules;
        }

        public async Task<UpdatedBodyShellPartResponse> Handle(UpdateBodyShellPartCommand request, CancellationToken cancellationToken)
        {
            BodyShellPart? bodyShellPart = await _bodyShellPartRepository.GetAsync(predicate: bsp => bsp.Id == request.Id, cancellationToken: cancellationToken);
            await _bodyShellPartBusinessRules.BodyShellPartShouldExistWhenSelected(bodyShellPart);
            bodyShellPart = _mapper.Map(request, bodyShellPart);

            await _bodyShellPartRepository.UpdateAsync(bodyShellPart!);

            UpdatedBodyShellPartResponse response = _mapper.Map<UpdatedBodyShellPartResponse>(bodyShellPart);
            return response;
        }
    }
}