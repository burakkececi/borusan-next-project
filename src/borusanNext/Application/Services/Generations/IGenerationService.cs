using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Generations;

public interface IGenerationService
{
    Task<Generation?> GetAsync(
        Expression<Func<Generation, bool>> predicate,
        Func<IQueryable<Generation>, IIncludableQueryable<Generation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Generation>?> GetListAsync(
        Expression<Func<Generation, bool>>? predicate = null,
        Func<IQueryable<Generation>, IOrderedQueryable<Generation>>? orderBy = null,
        Func<IQueryable<Generation>, IIncludableQueryable<Generation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Generation> AddAsync(Generation generation);
    Task<Generation> UpdateAsync(Generation generation);
    Task<Generation> DeleteAsync(Generation generation, bool permanent = false);
}
