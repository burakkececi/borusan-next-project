using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Licences;

public interface ILicenceService
{
    Task<Licence?> GetAsync(
        Expression<Func<Licence, bool>> predicate,
        Func<IQueryable<Licence>, IIncludableQueryable<Licence, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Licence>?> GetListAsync(
        Expression<Func<Licence, bool>>? predicate = null,
        Func<IQueryable<Licence>, IOrderedQueryable<Licence>>? orderBy = null,
        Func<IQueryable<Licence>, IIncludableQueryable<Licence, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Licence> AddAsync(Licence licence);
    Task<Licence> UpdateAsync(Licence licence);
    Task<Licence> DeleteAsync(Licence licence, bool permanent = false);
}
