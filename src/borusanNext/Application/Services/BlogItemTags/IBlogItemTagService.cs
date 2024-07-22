using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BlogItemTags;

public interface IBlogItemTagService
{
    Task<BlogItemTag?> GetAsync(
        Expression<Func<BlogItemTag, bool>> predicate,
        Func<IQueryable<BlogItemTag>, IIncludableQueryable<BlogItemTag, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BlogItemTag>?> GetListAsync(
        Expression<Func<BlogItemTag, bool>>? predicate = null,
        Func<IQueryable<BlogItemTag>, IOrderedQueryable<BlogItemTag>>? orderBy = null,
        Func<IQueryable<BlogItemTag>, IIncludableQueryable<BlogItemTag, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BlogItemTag> AddAsync(BlogItemTag blogItemTag);
    Task<BlogItemTag> UpdateAsync(BlogItemTag blogItemTag);
    Task<BlogItemTag> DeleteAsync(BlogItemTag blogItemTag, bool permanent = false);
}
