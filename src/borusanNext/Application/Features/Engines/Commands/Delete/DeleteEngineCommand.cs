using Application.Features.Engines.Constants;
using Application.Features.Engines.Constants;
using Application.Features.Engines.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Engines.Constants.EnginesOperationClaims;

namespace Application.Features.Engines.Commands.Delete;

public class DeleteEngineCommand : IRequest<DeletedEngineResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, EnginesOperationClaims.Delete];

    public class DeleteEngineCommandHandler : IRequestHandler<DeleteEngineCommand, DeletedEngineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEngineRepository _engineRepository;
        private readonly EngineBusinessRules _engineBusinessRules;

        public DeleteEngineCommandHandler(IMapper mapper, IEngineRepository engineRepository,
                                         EngineBusinessRules engineBusinessRules)
        {
            _mapper = mapper;
            _engineRepository = engineRepository;
            _engineBusinessRules = engineBusinessRules;
        }

        public async Task<DeletedEngineResponse> Handle(DeleteEngineCommand request, CancellationToken cancellationToken)
        {
            Engine? engine = await _engineRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _engineBusinessRules.EngineShouldExistWhenSelected(engine);

            await _engineRepository.DeleteAsync(engine!);

            DeletedEngineResponse response = _mapper.Map<DeletedEngineResponse>(engine);
            return response;
        }
    }
}