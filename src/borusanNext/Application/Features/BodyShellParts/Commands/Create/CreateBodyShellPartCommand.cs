using Application.Features.BodyShellParts.Constants;
using Application.Features.BodyShellParts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using Domain.Enums;
using static Application.Features.BodyShellParts.Constants.BodyShellPartsOperationClaims;

namespace Application.Features.BodyShellParts.Commands.Create;

public class CreateBodyShellPartCommand : IRequest<CreatedBodyShellPartResponse>, ISecuredRequest
{
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

    public string[] Roles => [Admin, Write, BodyShellPartsOperationClaims.Create];

    public class CreateBodyShellPartCommandHandler : IRequestHandler<CreateBodyShellPartCommand, CreatedBodyShellPartResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBodyShellPartRepository _bodyShellPartRepository;
        private readonly BodyShellPartBusinessRules _bodyShellPartBusinessRules;

        public CreateBodyShellPartCommandHandler(IMapper mapper, IBodyShellPartRepository bodyShellPartRepository,
                                         BodyShellPartBusinessRules bodyShellPartBusinessRules)
        {
            _mapper = mapper;
            _bodyShellPartRepository = bodyShellPartRepository;
            _bodyShellPartBusinessRules = bodyShellPartBusinessRules;
        }

        public async Task<CreatedBodyShellPartResponse> Handle(CreateBodyShellPartCommand request, CancellationToken cancellationToken)
        {
            BodyShellPart bodyShellPart = _mapper.Map<BodyShellPart>(request);

            await _bodyShellPartRepository.AddAsync(bodyShellPart);

            CreatedBodyShellPartResponse response = _mapper.Map<CreatedBodyShellPartResponse>(bodyShellPart);
            return response;
        }
    }
}