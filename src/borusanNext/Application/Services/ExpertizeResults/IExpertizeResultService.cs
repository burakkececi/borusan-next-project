using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ExpertizeResults;

public interface IExpertizeResultService
{
    Task<ExpertizeResult?> GetAsync(
        Expression<Func<ExpertizeResult, bool>> predicate,
        Func<IQueryable<ExpertizeResult>, IIncludableQueryable<ExpertizeResult, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ExpertizeResult>?> GetListAsync(
        Expression<Func<ExpertizeResult, bool>>? predicate = null,
        Func<IQueryable<ExpertizeResult>, IOrderedQueryable<ExpertizeResult>>? orderBy = null,
        Func<IQueryable<ExpertizeResult>, IIncludableQueryable<ExpertizeResult, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ExpertizeResult> AddAsync(ExpertizeResult expertizeResult);
    Task<ExpertizeResult> UpdateAsync(ExpertizeResult expertizeResult);
    Task<ExpertizeResult> DeleteAsync(ExpertizeResult expertizeResult, bool permanent = false);
}
