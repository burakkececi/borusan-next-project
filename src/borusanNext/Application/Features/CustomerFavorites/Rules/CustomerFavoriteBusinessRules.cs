using Application.Features.CustomerFavorites.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CustomerFavorites.Rules;

public class CustomerFavoriteBusinessRules : BaseBusinessRules
{
    private readonly ICustomerFavoriteRepository _customerFavoriteRepository;
    private readonly ILocalizationService _localizationService;

    public CustomerFavoriteBusinessRules(ICustomerFavoriteRepository customerFavoriteRepository, ILocalizationService localizationService)
    {
        _customerFavoriteRepository = customerFavoriteRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CustomerFavoritesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CustomerFavoriteShouldExistWhenSelected(CustomerFavorite? customerFavorite)
    {
        if (customerFavorite == null)
            await throwBusinessException(CustomerFavoritesBusinessMessages.CustomerFavoriteNotExists);
    }

    public async Task CustomerFavoriteIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CustomerFavorite? customerFavorite = await _customerFavoriteRepository.GetAsync(
            predicate: cf => cf.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerFavoriteShouldExistWhenSelected(customerFavorite);
    }
}