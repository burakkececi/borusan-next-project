using Application.Features.CarModels.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CarModels.Rules;

public class CarModelBusinessRules : BaseBusinessRules
{
    private readonly ICarModelRepository _carModelRepository;
    private readonly ILocalizationService _localizationService;

    public CarModelBusinessRules(ICarModelRepository carModelRepository, ILocalizationService localizationService)
    {
        _carModelRepository = carModelRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CarModelsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CarModelShouldExistWhenSelected(CarModel? carModel)
    {
        if (carModel == null)
            await throwBusinessException(CarModelsBusinessMessages.CarModelNotExists);
    }

    public async Task CarModelIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CarModel? carModel = await _carModelRepository.GetAsync(
            predicate: cm => cm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CarModelShouldExistWhenSelected(carModel);
    }
}