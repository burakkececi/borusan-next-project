using Application.Features.Engines.Constants;
using Application.Features.Engines.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Engines.Constants.EnginesOperationClaims;

namespace Application.Features.Engines.Queries.GetById;

public class GetByIdEngineQuery : IRequest<GetByIdEngineResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdEngineQueryHandler : IRequestHandler<GetByIdEngineQuery, GetByIdEngineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEngineRepository _engineRepository;
        private readonly EngineBusinessRules _engineBusinessRules;

        public GetByIdEngineQueryHandler(IMapper mapper, IEngineRepository engineRepository, EngineBusinessRules engineBusinessRules)
        {
            _mapper = mapper;
            _engineRepository = engineRepository;
            _engineBusinessRules = engineBusinessRules;
        }

        public async Task<GetByIdEngineResponse> Handle(GetByIdEngineQuery request, CancellationToken cancellationToken)
        {
            Engine? engine = await _engineRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _engineBusinessRules.EngineShouldExistWhenSelected(engine);

            GetByIdEngineResponse response = _mapper.Map<GetByIdEngineResponse>(engine);
            return response;
        }
    }
}