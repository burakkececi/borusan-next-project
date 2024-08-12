using Application.Features.AdvertImages.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.AdvertImages.Rules;

public class AdvertImageBusinessRules : BaseBusinessRules
{
    private readonly IAdvertImageRepository _advertImageRepository;
    private readonly IAdvertRepository _advertRepository; 
    private readonly ILocalizationService _localizationService;

    public AdvertImageBusinessRules(
        IAdvertImageRepository advertImageRepository,
        IAdvertRepository advertRepository, 
        ILocalizationService localizationService
    )
    {
        _advertImageRepository = advertImageRepository;
        _advertRepository = advertRepository; 
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AdvertImagesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AdvertImageShouldExistWhenSelected(AdvertImage? advertImage)
    {
        if (advertImage == null)
            await throwBusinessException(AdvertImagesBusinessMessages.AdvertImageNotExists);
    }

    public async Task AdvertImageIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        AdvertImage? advertImage = await _advertImageRepository.GetAsync(
            predicate: ai => ai.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AdvertImageShouldExistWhenSelected(advertImage);
    }

    public async Task AdvertIdShouldExistWhenSelected(Guid advertId, CancellationToken cancellationToken)
    {
        var advert = await _advertRepository.GetAsync(
            predicate: a => a.Id == advertId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (advert == null)
        {
            string messageKey = AdvertImagesBusinessMessages.AdvertNotExists; 
            await throwBusinessException(messageKey);
        }
    }
}
