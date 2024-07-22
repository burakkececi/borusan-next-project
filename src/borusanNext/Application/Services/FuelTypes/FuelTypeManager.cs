using Application.Features.FuelTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FuelTypes;

public class FuelTypeManager : IFuelTypeService
{
    private readonly IFuelTypeRepository _fuelTypeRepository;
    private readonly FuelTypeBusinessRules _fuelTypeBusinessRules;

    public FuelTypeManager(IFuelTypeRepository fuelTypeRepository, FuelTypeBusinessRules fuelTypeBusinessRules)
    {
        _fuelTypeRepository = fuelTypeRepository;
        _fuelTypeBusinessRules = fuelTypeBusinessRules;
    }

    public async Task<FuelType?> GetAsync(
        Expression<Func<FuelType, bool>> predicate,
        Func<IQueryable<FuelType>, IIncludableQueryable<FuelType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        FuelType? fuelType = await _fuelTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return fuelType;
    }

    public async Task<IPaginate<FuelType>?> GetListAsync(
        Expression<Func<FuelType, bool>>? predicate = null,
        Func<IQueryable<FuelType>, IOrderedQueryable<FuelType>>? orderBy = null,
        Func<IQueryable<FuelType>, IIncludableQueryable<FuelType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<FuelType> fuelTypeList = await _fuelTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return fuelTypeList;
    }

    public async Task<FuelType> AddAsync(FuelType fuelType)
    {
        FuelType addedFuelType = await _fuelTypeRepository.AddAsync(fuelType);

        return addedFuelType;
    }

    public async Task<FuelType> UpdateAsync(FuelType fuelType)
    {
        FuelType updatedFuelType = await _fuelTypeRepository.UpdateAsync(fuelType);

        return updatedFuelType;
    }

    public async Task<FuelType> DeleteAsync(FuelType fuelType, bool permanent = false)
    {
        FuelType deletedFuelType = await _fuelTypeRepository.DeleteAsync(fuelType);

        return deletedFuelType;
    }
}
