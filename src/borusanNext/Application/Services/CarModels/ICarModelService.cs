using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CarModels;

public interface ICarModelService
{
    Task<CarModel?> GetAsync(
        Expression<Func<CarModel, bool>> predicate,
        Func<IQueryable<CarModel>, IIncludableQueryable<CarModel, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CarModel>?> GetListAsync(
        Expression<Func<CarModel, bool>>? predicate = null,
        Func<IQueryable<CarModel>, IOrderedQueryable<CarModel>>? orderBy = null,
        Func<IQueryable<CarModel>, IIncludableQueryable<CarModel, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CarModel> AddAsync(CarModel carModel);
    Task<CarModel> UpdateAsync(CarModel carModel);
    Task<CarModel> DeleteAsync(CarModel carModel, bool permanent = false);
}
