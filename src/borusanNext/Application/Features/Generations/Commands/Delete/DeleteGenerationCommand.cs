using Application.Features.Generations.Constants;
using Application.Features.Generations.Constants;
using Application.Features.Generations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Generations.Constants.GenerationsOperationClaims;

namespace Application.Features.Generations.Commands.Delete;

public class DeleteGenerationCommand : IRequest<DeletedGenerationResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, GenerationsOperationClaims.Delete];

    public class DeleteGenerationCommandHandler : IRequestHandler<DeleteGenerationCommand, DeletedGenerationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenerationRepository _generationRepository;
        private readonly GenerationBusinessRules _generationBusinessRules;

        public DeleteGenerationCommandHandler(IMapper mapper, IGenerationRepository generationRepository,
                                         GenerationBusinessRules generationBusinessRules)
        {
            _mapper = mapper;
            _generationRepository = generationRepository;
            _generationBusinessRules = generationBusinessRules;
        }

        public async Task<DeletedGenerationResponse> Handle(DeleteGenerationCommand request, CancellationToken cancellationToken)
        {
            Generation? generation = await _generationRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _generationBusinessRules.GenerationShouldExistWhenSelected(generation);

            await _generationRepository.DeleteAsync(generation!);

            DeletedGenerationResponse response = _mapper.Map<DeletedGenerationResponse>(generation);
            return response;
        }
    }
}