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
    private readonly IEngineRepository _engineRepository;
    private readonly IBodyTypeRepository _bodyTypeRepository;
    private readonly ITransmissionRepository _transmissionRepository;
    private readonly IExpertizeResultRepository _expertizeResultRepository; 
    private readonly ISellerRepository _sellerRepository;
    private readonly ILocalizationService _localizationService;

    public CarBusinessRules(
        ICarRepository carRepository,
        ICarModelRepository carModelRepository,
        ICarColorRepository carColorRepository, 
        IEngineRepository engineRepository,
        IBodyTypeRepository bodyTypeRepository,
        ITransmissionRepository transmissionRepository,
        IExpertizeResultRepository expertizeResultRepository, 
        ISellerRepository sellerRepository,
        ILocalizationService localizationService
    )
    {
        _carRepository = carRepository;
        _carModelRepository = carModelRepository;
        _carColorRepository = carColorRepository; 
        _engineRepository = engineRepository;
        _bodyTypeRepository = bodyTypeRepository;
        _transmissionRepository = transmissionRepository;
        _expertizeResultRepository = expertizeResultRepository; 
        _sellerRepository = sellerRepository;
        _localizationService = localizationService;
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

    public async Task EngineIdShouldExistWhenSelected(Guid engineId, CancellationToken cancellationToken)
    {
        Engine? engine = await _engineRepository.GetAsync(
            predicate: e => e.Id == engineId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (engine == null)
        {
            await throwBusinessException(CarsBusinessMessages.EngineNotExists);
        }
    }

    public async Task BodyTypeIdShouldExistWhenSelected(Guid bodyTypeId, CancellationToken cancellationToken)
    {
        BodyType? bodyType = await _bodyTypeRepository.GetAsync(
            predicate: bt => bt.Id == bodyTypeId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (bodyType == null)
        {
            await throwBusinessException(CarsBusinessMessages.BodyTypeNotExists);
        }
    }

    public async Task TransmissionIdShouldExistWhenSelected(Guid transmissionId, CancellationToken cancellationToken)
    {
        Transmission? transmission = await _transmissionRepository.GetAsync(
            predicate: t => t.Id == transmissionId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (transmission == null)
        {
            await throwBusinessException(CarsBusinessMessages.TransmissionNotExists);
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
}
