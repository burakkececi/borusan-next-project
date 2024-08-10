using Application.Features.GenerationImages.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.GenerationImages.Rules;

public class GenerationImageBusinessRules : BaseBusinessRules
{
    private readonly IGenerationImageRepository _generationImageRepository;
    private readonly IGenerationRepository _generationRepository;
    private readonly ILocalizationService _localizationService;

    public GenerationImageBusinessRules(IGenerationImageRepository generationImageRepository, ILocalizationService localizationService, IGenerationRepository generationRepository)
    {
        _generationImageRepository = generationImageRepository;
        _localizationService = localizationService;
        _generationRepository = generationRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, GenerationImagesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task GenerationImageShouldExistWhenSelected(GenerationImage? generationImage)
    {
        if (generationImage == null)
            await throwBusinessException(GenerationImagesBusinessMessages.GenerationImageNotExists);
    }

    public async Task GenerationImageIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        GenerationImage? generationImage = await _generationImageRepository.GetAsync(
            predicate: gi => gi.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GenerationImageShouldExistWhenSelected(generationImage);
    }

    public async Task GenerationIdShouldExistWhenBindingToGenerationImages(Guid id, CancellationToken cancellationToken)
    {
        Generation? generation = await _generationRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
            );

        if (generation == null)
            await throwBusinessException(GenerationImagesBusinessMessages.GenerationNotExists);
    }
}