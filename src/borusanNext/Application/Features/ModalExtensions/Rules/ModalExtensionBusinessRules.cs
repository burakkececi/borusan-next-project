using Application.Features.ModalExtensions.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ModalExtensions.Rules;

public class ModalExtensionBusinessRules : BaseBusinessRules
{
    private readonly IModalExtensionRepository _modalExtensionRepository;
    private readonly ILocalizationService _localizationService;

    public ModalExtensionBusinessRules(IModalExtensionRepository modalExtensionRepository, ILocalizationService localizationService)
    {
        _modalExtensionRepository = modalExtensionRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ModalExtensionsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ModalExtensionShouldExistWhenSelected(ModalExtension? modalExtension)
    {
        if (modalExtension == null)
            await throwBusinessException(ModalExtensionsBusinessMessages.ModalExtensionNotExists);
    }

    public async Task ModalExtensionIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ModalExtension? modalExtension = await _modalExtensionRepository.GetAsync(
            predicate: me => me.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ModalExtensionShouldExistWhenSelected(modalExtension);
    }
}