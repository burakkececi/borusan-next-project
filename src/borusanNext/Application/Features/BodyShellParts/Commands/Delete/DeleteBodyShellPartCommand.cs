using Application.Features.BodyShellParts.Constants;
using Application.Features.BodyShellParts.Constants;
using Application.Features.BodyShellParts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BodyShellParts.Constants.BodyShellPartsOperationClaims;

namespace Application.Features.BodyShellParts.Commands.Delete;

public class DeleteBodyShellPartCommand : IRequest<DeletedBodyShellPartResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, BodyShellPartsOperationClaims.Delete];

    public class DeleteBodyShellPartCommandHandler : IRequestHandler<DeleteBodyShellPartCommand, DeletedBodyShellPartResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBodyShellPartRepository _bodyShellPartRepository;
        private readonly BodyShellPartBusinessRules _bodyShellPartBusinessRules;

        public DeleteBodyShellPartCommandHandler(IMapper mapper, IBodyShellPartRepository bodyShellPartRepository,
                                         BodyShellPartBusinessRules bodyShellPartBusinessRules)
        {
            _mapper = mapper;
            _bodyShellPartRepository = bodyShellPartRepository;
            _bodyShellPartBusinessRules = bodyShellPartBusinessRules;
        }

        public async Task<DeletedBodyShellPartResponse> Handle(DeleteBodyShellPartCommand request, CancellationToken cancellationToken)
        {
            BodyShellPart? bodyShellPart = await _bodyShellPartRepository.GetAsync(predicate: bsp => bsp.Id == request.Id, cancellationToken: cancellationToken);
            await _bodyShellPartBusinessRules.BodyShellPartShouldExistWhenSelected(bodyShellPart);

            await _bodyShellPartRepository.DeleteAsync(bodyShellPart!);

            DeletedBodyShellPartResponse response = _mapper.Map<DeletedBodyShellPartResponse>(bodyShellPart);
            return response;
        }
    }
}