using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BodyTypes;

public interface IBodyTypeService
{
    Task<BodyType?> GetAsync(
        Expression<Func<BodyType, bool>> predicate,
        Func<IQueryable<BodyType>, IIncludableQueryable<BodyType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BodyType>?> GetListAsync(
        Expression<Func<BodyType, bool>>? predicate = null,
        Func<IQueryable<BodyType>, IOrderedQueryable<BodyType>>? orderBy = null,
        Func<IQueryable<BodyType>, IIncludableQueryable<BodyType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BodyType> AddAsync(BodyType bodyType);
    Task<BodyType> UpdateAsync(BodyType bodyType);
    Task<BodyType> DeleteAsync(BodyType bodyType, bool permanent = false);
}
