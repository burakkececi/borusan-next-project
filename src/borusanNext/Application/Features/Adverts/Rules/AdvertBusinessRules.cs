using Application.Features.Adverts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Adverts.Rules;

public class AdvertBusinessRules : BaseBusinessRules
{
    private readonly IAdvertRepository _advertRepository;
    private readonly ICarRepository _carRepository;
    private readonly ILocalizationService _localizationService;

    public AdvertBusinessRules(
        IAdvertRepository advertRepository,
        ICarRepository carRepository, 
        ILocalizationService localizationService
    )
    {
        _advertRepository = advertRepository;
        _carRepository = carRepository; 
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AdvertsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AdvertShouldExistWhenSelected(Advert? advert)
    {
        if (advert == null)
            await throwBusinessException(AdvertsBusinessMessages.AdvertNotExists);
    }

    public async Task AdvertIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Advert? advert = await _advertRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AdvertShouldExistWhenSelected(advert);
    }

    public async Task CarIdShouldExistWhenSelected(Guid carId, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetAsync(
            predicate: c => c.Id == carId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (car == null)
        {
            string messageKey = AdvertsBusinessMessages.CarNotExists;
            await throwBusinessException(messageKey);
        }
    }
}
