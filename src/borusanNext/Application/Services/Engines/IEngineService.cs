using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Engines;

public interface IEngineService
{
    Task<Engine?> GetAsync(
        Expression<Func<Engine, bool>> predicate,
        Func<IQueryable<Engine>, IIncludableQueryable<Engine, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Engine>?> GetListAsync(
        Expression<Func<Engine, bool>>? predicate = null,
        Func<IQueryable<Engine>, IOrderedQueryable<Engine>>? orderBy = null,
        Func<IQueryable<Engine>, IIncludableQueryable<Engine, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Engine> AddAsync(Engine engine);
    Task<Engine> UpdateAsync(Engine engine);
    Task<Engine> DeleteAsync(Engine engine, bool permanent = false);
}
