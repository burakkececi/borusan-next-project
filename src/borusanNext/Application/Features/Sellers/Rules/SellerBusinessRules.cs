using Application.Features.Sellers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Sellers.Constants;

namespace Application.Features.Sellers.Rules;

public class SellerBusinessRules : BaseBusinessRules
{
    private readonly ISellerRepository _sellerRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILocalizationService _localizationService;

    public SellerBusinessRules(ISellerRepository sellerRepository, ILocalizationService localizationService, IUserRepository userRepository)
    {
        _sellerRepository = sellerRepository;
        _localizationService = localizationService;
        _userRepository = userRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SellersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SellerShouldExistWhenSelected(Seller? seller)
    {
        if (seller == null)
            await throwBusinessException(SellersBusinessMessages.SellerNotExists);
    }

    public async Task SellerIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Seller? seller = await _sellerRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SellerShouldExistWhenSelected(seller);
    }

    public async Task UserIdShouldExistWhenBindingToSeller(Guid id, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (user == null)
            await throwBusinessException(SellersBusinessMessages.UserIdNotExist);
    }
}