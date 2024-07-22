using Application.Features.Generations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Generations.Rules;

public class GenerationBusinessRules : BaseBusinessRules
{
    private readonly IGenerationRepository _generationRepository;
    private readonly ILocalizationService _localizationService;

    public GenerationBusinessRules(IGenerationRepository generationRepository, ILocalizationService localizationService)
    {
        _generationRepository = generationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, GenerationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task GenerationShouldExistWhenSelected(Generation? generation)
    {
        if (generation == null)
            await throwBusinessException(GenerationsBusinessMessages.GenerationNotExists);
    }

    public async Task GenerationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Generation? generation = await _generationRepository.GetAsync(
            predicate: g => g.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GenerationShouldExistWhenSelected(generation);
    }
}