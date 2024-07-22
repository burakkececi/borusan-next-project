using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FuelTypes;

public interface IFuelTypeService
{
    Task<FuelType?> GetAsync(
        Expression<Func<FuelType, bool>> predicate,
        Func<IQueryable<FuelType>, IIncludableQueryable<FuelType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<FuelType>?> GetListAsync(
        Expression<Func<FuelType, bool>>? predicate = null,
        Func<IQueryable<FuelType>, IOrderedQueryable<FuelType>>? orderBy = null,
        Func<IQueryable<FuelType>, IIncludableQueryable<FuelType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<FuelType> AddAsync(FuelType fuelType);
    Task<FuelType> UpdateAsync(FuelType fuelType);
    Task<FuelType> DeleteAsync(FuelType fuelType, bool permanent = false);
}
