using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FuelConsumptions;

public interface IFuelConsumptionService
{
    Task<FuelConsumption?> GetAsync(
        Expression<Func<FuelConsumption, bool>> predicate,
        Func<IQueryable<FuelConsumption>, IIncludableQueryable<FuelConsumption, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<FuelConsumption>?> GetListAsync(
        Expression<Func<FuelConsumption, bool>>? predicate = null,
        Func<IQueryable<FuelConsumption>, IOrderedQueryable<FuelConsumption>>? orderBy = null,
        Func<IQueryable<FuelConsumption>, IIncludableQueryable<FuelConsumption, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<FuelConsumption> AddAsync(FuelConsumption fuelConsumption);
    Task<FuelConsumption> UpdateAsync(FuelConsumption fuelConsumption);
    Task<FuelConsumption> DeleteAsync(FuelConsumption fuelConsumption, bool permanent = false);
}
