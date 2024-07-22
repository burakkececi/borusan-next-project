using Application.Features.FuelConsumptions.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.FuelConsumptions.Rules;

public class FuelConsumptionBusinessRules : BaseBusinessRules
{
    private readonly IFuelConsumptionRepository _fuelConsumptionRepository;
    private readonly ILocalizationService _localizationService;

    public FuelConsumptionBusinessRules(IFuelConsumptionRepository fuelConsumptionRepository, ILocalizationService localizationService)
    {
        _fuelConsumptionRepository = fuelConsumptionRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, FuelConsumptionsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task FuelConsumptionShouldExistWhenSelected(FuelConsumption? fuelConsumption)
    {
        if (fuelConsumption == null)
            await throwBusinessException(FuelConsumptionsBusinessMessages.FuelConsumptionNotExists);
    }

    public async Task FuelConsumptionIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        FuelConsumption? fuelConsumption = await _fuelConsumptionRepository.GetAsync(
            predicate: fc => fc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FuelConsumptionShouldExistWhenSelected(fuelConsumption);
    }
}