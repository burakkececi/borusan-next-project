using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BodyShellParts;

public interface IBodyShellPartService
{
    Task<BodyShellPart?> GetAsync(
        Expression<Func<BodyShellPart, bool>> predicate,
        Func<IQueryable<BodyShellPart>, IIncludableQueryable<BodyShellPart, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BodyShellPart>?> GetListAsync(
        Expression<Func<BodyShellPart, bool>>? predicate = null,
        Func<IQueryable<BodyShellPart>, IOrderedQueryable<BodyShellPart>>? orderBy = null,
        Func<IQueryable<BodyShellPart>, IIncludableQueryable<BodyShellPart, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BodyShellPart> AddAsync(BodyShellPart bodyShellPart);
    Task<BodyShellPart> UpdateAsync(BodyShellPart bodyShellPart);
    Task<BodyShellPart> DeleteAsync(BodyShellPart bodyShellPart, bool permanent = false);
}
