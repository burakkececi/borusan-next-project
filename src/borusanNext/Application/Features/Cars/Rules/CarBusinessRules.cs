using Application.Features.Cars.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Cars.Rules;

public class CarBusinessRules : BaseBusinessRules
{
    private readonly ICarRepository _carRepository;
    private readonly ICarModelRepository _carModelRepository;
    private readonly ICarColorRepository _carColorRepository; 
    private readonly IExpertizeResultRepository _expertizeResultRepository; 
    private readonly ISellerRepository _sellerRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IModalExtensionRepository _modalExtensionRepository;

    public CarBusinessRules(
        ICarRepository carRepository,
        ICarModelRepository carModelRepository,
        ICarColorRepository carColorRepository, 
        IExpertizeResultRepository expertizeResultRepository, 
        ISellerRepository sellerRepository,
        ILocalizationService localizationService,
        IModalExtensionRepository modalExtensionRepository
    )
    {
        _carRepository = carRepository;
        _carModelRepository = carModelRepository;
        _carColorRepository = carColorRepository; 
        _expertizeResultRepository = expertizeResultRepository; 
        _sellerRepository = sellerRepository;
        _localizationService = localizationService;
        _modalExtensionRepository = modalExtensionRepository;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CarsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CarShouldExistWhenSelected(Car? car)
    {
        if (car == null)
            await throwBusinessException(CarsBusinessMessages.CarNotExists);
    }

    public async Task CarIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Car? car = await _carRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CarShouldExistWhenSelected(car);
    }

    public async Task CarModelIdShouldExistWhenSelected(Guid carModelId, CancellationToken cancellationToken)
    {
        CarModel? carModel = await _carModelRepository.GetAsync(
            predicate: cm => cm.Id == carModelId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (carModel == null)
        {
            await throwBusinessException(CarsBusinessMessages.CarModelNotExists);
        }
    }

    public async Task CarColorIdShouldExistWhenSelected(Guid carColorId, CancellationToken cancellationToken) 
    {
        CarColor? carColor = await _carColorRepository.GetAsync(
            predicate: cc => cc.Id == carColorId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (carColor == null)
        {
            await throwBusinessException(CarsBusinessMessages.CarColorNotExists); 
        }
    }
    public async Task ExpertizeResultIdShouldExistWhenSelected(Guid expertizeResultId, CancellationToken cancellationToken) 
    {
        ExpertizeResult? expertizeResult = await _expertizeResultRepository.GetAsync(
            predicate: er => er.Id == expertizeResultId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (expertizeResult == null)
        {
            await throwBusinessException(CarsBusinessMessages.ExpertizeResultNotExists);
        }
    }

    public async Task SellerIdShouldExistWhenSelected(Guid sellerId, CancellationToken cancellationToken)
    {
        Seller? seller = await _sellerRepository.GetAsync(
            predicate: s => s.Id == sellerId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (seller == null)
        {
            await throwBusinessException(CarsBusinessMessages.SellerNotExists);
        }
    }

    public async Task ModalExtensionIdShouldExistWhenSelected(Guid modalExtensionId, CancellationToken cancellationToken)
    {
        ModalExtension? modalExtension = await _modalExtensionRepository.GetAsync(
            predicate: m => m.Id == modalExtensionId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (modalExtension == null)
        {
            await throwBusinessException(CarsBusinessMessages.ModalExtensionNotExist);
        }
    }
}
