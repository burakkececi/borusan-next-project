using Application.Features.BodyShellParts.Constants;
using Application.Features.BodyShellParts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BodyShellParts.Constants.BodyShellPartsOperationClaims;

namespace Application.Features.BodyShellParts.Queries.GetById;

public class GetByIdBodyShellPartQuery : IRequest<GetByIdBodyShellPartResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBodyShellPartQueryHandler : IRequestHandler<GetByIdBodyShellPartQuery, GetByIdBodyShellPartResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBodyShellPartRepository _bodyShellPartRepository;
        private readonly BodyShellPartBusinessRules _bodyShellPartBusinessRules;

        public GetByIdBodyShellPartQueryHandler(IMapper mapper, IBodyShellPartRepository bodyShellPartRepository, BodyShellPartBusinessRules bodyShellPartBusinessRules)
        {
            _mapper = mapper;
            _bodyShellPartRepository = bodyShellPartRepository;
            _bodyShellPartBusinessRules = bodyShellPartBusinessRules;
        }

        public async Task<GetByIdBodyShellPartResponse> Handle(GetByIdBodyShellPartQuery request, CancellationToken cancellationToken)
        {
            BodyShellPart? bodyShellPart = await _bodyShellPartRepository.GetAsync(predicate: bsp => bsp.Id == request.Id, cancellationToken: cancellationToken);
            await _bodyShellPartBusinessRules.BodyShellPartShouldExistWhenSelected(bodyShellPart);

            GetByIdBodyShellPartResponse response = _mapper.Map<GetByIdBodyShellPartResponse>(bodyShellPart);
            return response;
        }
    }
}