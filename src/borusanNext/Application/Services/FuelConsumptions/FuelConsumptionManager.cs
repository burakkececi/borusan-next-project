using Application.Features.FuelConsumptions.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FuelConsumptions;

public class FuelConsumptionManager : IFuelConsumptionService
{
    private readonly IFuelConsumptionRepository _fuelConsumptionRepository;
    private readonly FuelConsumptionBusinessRules _fuelConsumptionBusinessRules;

    public FuelConsumptionManager(IFuelConsumptionRepository fuelConsumptionRepository, FuelConsumptionBusinessRules fuelConsumptionBusinessRules)
    {
        _fuelConsumptionRepository = fuelConsumptionRepository;
        _fuelConsumptionBusinessRules = fuelConsumptionBusinessRules;
    }

    public async Task<FuelConsumption?> GetAsync(
        Expression<Func<FuelConsumption, bool>> predicate,
        Func<IQueryable<FuelConsumption>, IIncludableQueryable<FuelConsumption, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        FuelConsumption? fuelConsumption = await _fuelConsumptionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return fuelConsumption;
    }

    public async Task<IPaginate<FuelConsumption>?> GetListAsync(
        Expression<Func<FuelConsumption, bool>>? predicate = null,
        Func<IQueryable<FuelConsumption>, IOrderedQueryable<FuelConsumption>>? orderBy = null,
        Func<IQueryable<FuelConsumption>, IIncludableQueryable<FuelConsumption, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<FuelConsumption> fuelConsumptionList = await _fuelConsumptionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return fuelConsumptionList;
    }

    public async Task<FuelConsumption> AddAsync(FuelConsumption fuelConsumption)
    {
        FuelConsumption addedFuelConsumption = await _fuelConsumptionRepository.AddAsync(fuelConsumption);

        return addedFuelConsumption;
    }

    public async Task<FuelConsumption> UpdateAsync(FuelConsumption fuelConsumption)
    {
        FuelConsumption updatedFuelConsumption = await _fuelConsumptionRepository.UpdateAsync(fuelConsumption);

        return updatedFuelConsumption;
    }

    public async Task<FuelConsumption> DeleteAsync(FuelConsumption fuelConsumption, bool permanent = false)
    {
        FuelConsumption deletedFuelConsumption = await _fuelConsumptionRepository.DeleteAsync(fuelConsumption);

        return deletedFuelConsumption;
    }
}
