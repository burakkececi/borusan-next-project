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
    private readonly IGenerationRepository _generationRepository;
    private readonly ICarModelRepository _carModelRepository;
    private readonly ILocalizationService _localizationService;

    public ModalExtensionBusinessRules(IModalExtensionRepository modalExtensionRepository, ILocalizationService localizationService, IGenerationRepository generationRepository, ICarModelRepository carModelRepository)
    {
        _modalExtensionRepository = modalExtensionRepository;
        _localizationService = localizationService;
        _generationRepository = generationRepository;
        _carModelRepository = carModelRepository;
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

    public async Task GenerationIdShouldExistWhenBindingToModalExtensions(Guid id, CancellationToken cancellationToken)
    {
        Generation? generation = await _generationRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
            );

        if (generation == null)
            await throwBusinessException(ModalExtensionsBusinessMessages.GenerationNotExists);
    }

    public async Task CarModelIdShouldExistWhenBindingToModalExtensions(Guid id, CancellationToken cancellationToken)
    {
        CarModel? carModel = await _carModelRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
            );

        if (carModel == null)
            await throwBusinessException(ModalExtensionsBusinessMessages.CarModelNotExists);
    }
}