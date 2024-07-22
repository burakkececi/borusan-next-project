using Application.Features.CarModels.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CarModels;

public class CarModelManager : ICarModelService
{
    private readonly ICarModelRepository _carModelRepository;
    private readonly CarModelBusinessRules _carModelBusinessRules;

    public CarModelManager(ICarModelRepository carModelRepository, CarModelBusinessRules carModelBusinessRules)
    {
        _carModelRepository = carModelRepository;
        _carModelBusinessRules = carModelBusinessRules;
    }

    public async Task<CarModel?> GetAsync(
        Expression<Func<CarModel, bool>> predicate,
        Func<IQueryable<CarModel>, IIncludableQueryable<CarModel, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CarModel? carModel = await _carModelRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return carModel;
    }

    public async Task<IPaginate<CarModel>?> GetListAsync(
        Expression<Func<CarModel, bool>>? predicate = null,
        Func<IQueryable<CarModel>, IOrderedQueryable<CarModel>>? orderBy = null,
        Func<IQueryable<CarModel>, IIncludableQueryable<CarModel, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CarModel> carModelList = await _carModelRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return carModelList;
    }

    public async Task<CarModel> AddAsync(CarModel carModel)
    {
        CarModel addedCarModel = await _carModelRepository.AddAsync(carModel);

        return addedCarModel;
    }

    public async Task<CarModel> UpdateAsync(CarModel carModel)
    {
        CarModel updatedCarModel = await _carModelRepository.UpdateAsync(carModel);

        return updatedCarModel;
    }

    public async Task<CarModel> DeleteAsync(CarModel carModel, bool permanent = false)
    {
        CarModel deletedCarModel = await _carModelRepository.DeleteAsync(carModel);

        return deletedCarModel;
    }
}
