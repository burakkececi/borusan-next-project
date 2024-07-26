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
    private readonly ILocalizationService _localizationService;

    public GenerationImageBusinessRules(IGenerationImageRepository generationImageRepository, ILocalizationService localizationService)
    {
        _generationImageRepository = generationImageRepository;
        _localizationService = localizationService;
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
}