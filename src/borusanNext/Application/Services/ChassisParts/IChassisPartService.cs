using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ChassisParts;

public interface IChassisPartService
{
    Task<ChassisPart?> GetAsync(
        Expression<Func<ChassisPart, bool>> predicate,
        Func<IQueryable<ChassisPart>, IIncludableQueryable<ChassisPart, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ChassisPart>?> GetListAsync(
        Expression<Func<ChassisPart, bool>>? predicate = null,
        Func<IQueryable<ChassisPart>, IOrderedQueryable<ChassisPart>>? orderBy = null,
        Func<IQueryable<ChassisPart>, IIncludableQueryable<ChassisPart, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ChassisPart> AddAsync(ChassisPart chassisPart);
    Task<ChassisPart> UpdateAsync(ChassisPart chassisPart);
    Task<ChassisPart> DeleteAsync(ChassisPart chassisPart, bool permanent = false);
}
