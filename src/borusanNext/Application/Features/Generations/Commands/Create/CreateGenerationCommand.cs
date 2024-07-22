using Application.Features.Generations.Constants;
using Application.Features.Generations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Generations.Constants.GenerationsOperationClaims;

namespace Application.Features.Generations.Commands.Create;

public class CreateGenerationCommand : IRequest<CreatedGenerationResponse>, ISecuredRequest
{
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, GenerationsOperationClaims.Create];

    public class CreateGenerationCommandHandler : IRequestHandler<CreateGenerationCommand, CreatedGenerationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenerationRepository _generationRepository;
        private readonly GenerationBusinessRules _generationBusinessRules;

        public CreateGenerationCommandHandler(IMapper mapper, IGenerationRepository generationRepository,
                                         GenerationBusinessRules generationBusinessRules)
        {
            _mapper = mapper;
            _generationRepository = generationRepository;
            _generationBusinessRules = generationBusinessRules;
        }

        public async Task<CreatedGenerationResponse> Handle(CreateGenerationCommand request, CancellationToken cancellationToken)
        {
            Generation generation = _mapper.Map<Generation>(request);

            await _generationRepository.AddAsync(generation);

            CreatedGenerationResponse response = _mapper.Map<CreatedGenerationResponse>(generation);
            return response;
        }
    }
}