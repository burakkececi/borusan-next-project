using Application.Features.FuelTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.FuelTypes.Rules;

public class FuelTypeBusinessRules : BaseBusinessRules
{
    private readonly IFuelTypeRepository _fuelTypeRepository;
    private readonly ILocalizationService _localizationService;

    public FuelTypeBusinessRules(IFuelTypeRepository fuelTypeRepository, ILocalizationService localizationService)
    {
        _fuelTypeRepository = fuelTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, FuelTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task FuelTypeShouldExistWhenSelected(FuelType? fuelType)
    {
        if (fuelType == null)
            await throwBusinessException(FuelTypesBusinessMessages.FuelTypeNotExists);
    }

    public async Task FuelTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        FuelType? fuelType = await _fuelTypeRepository.GetAsync(
            predicate: ft => ft.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FuelTypeShouldExistWhenSelected(fuelType);
    }
}