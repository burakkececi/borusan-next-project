using Application.Features.Generations.Constants;
using Application.Features.Generations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Generations.Constants.GenerationsOperationClaims;

namespace Application.Features.Generations.Commands.Update;

public class UpdateGenerationCommand : IRequest<UpdatedGenerationResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, GenerationsOperationClaims.Update];

    public class UpdateGenerationCommandHandler : IRequestHandler<UpdateGenerationCommand, UpdatedGenerationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenerationRepository _generationRepository;
        private readonly GenerationBusinessRules _generationBusinessRules;

        public UpdateGenerationCommandHandler(IMapper mapper, IGenerationRepository generationRepository,
                                         GenerationBusinessRules generationBusinessRules)
        {
            _mapper = mapper;
            _generationRepository = generationRepository;
            _generationBusinessRules = generationBusinessRules;
        }

        public async Task<UpdatedGenerationResponse> Handle(UpdateGenerationCommand request, CancellationToken cancellationToken)
        {
            Generation? generation = await _generationRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _generationBusinessRules.GenerationShouldExistWhenSelected(generation);
            generation = _mapper.Map(request, generation);

            await _generationRepository.UpdateAsync(generation!);

            UpdatedGenerationResponse response = _mapper.Map<UpdatedGenerationResponse>(generation);
            return response;
        }
    }
}