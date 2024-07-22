using Application.Features.Generations.Constants;
using Application.Features.Generations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Generations.Constants.GenerationsOperationClaims;

namespace Application.Features.Generations.Queries.GetById;

public class GetByIdGenerationQuery : IRequest<GetByIdGenerationResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdGenerationQueryHandler : IRequestHandler<GetByIdGenerationQuery, GetByIdGenerationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenerationRepository _generationRepository;
        private readonly GenerationBusinessRules _generationBusinessRules;

        public GetByIdGenerationQueryHandler(IMapper mapper, IGenerationRepository generationRepository, GenerationBusinessRules generationBusinessRules)
        {
            _mapper = mapper;
            _generationRepository = generationRepository;
            _generationBusinessRules = generationBusinessRules;
        }

        public async Task<GetByIdGenerationResponse> Handle(GetByIdGenerationQuery request, CancellationToken cancellationToken)
        {
            Generation? generation = await _generationRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _generationBusinessRules.GenerationShouldExistWhenSelected(generation);

            GetByIdGenerationResponse response = _mapper.Map<GetByIdGenerationResponse>(generation);
            return response;
        }
    }
}