using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AdvertImages;

public interface IAdvertImageService
{
    Task<AdvertImage?> GetAsync(
        Expression<Func<AdvertImage, bool>> predicate,
        Func<IQueryable<AdvertImage>, IIncludableQueryable<AdvertImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AdvertImage>?> GetListAsync(
        Expression<Func<AdvertImage, bool>>? predicate = null,
        Func<IQueryable<AdvertImage>, IOrderedQueryable<AdvertImage>>? orderBy = null,
        Func<IQueryable<AdvertImage>, IIncludableQueryable<AdvertImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AdvertImage> AddAsync(AdvertImage advertImage);
    Task<AdvertImage> UpdateAsync(AdvertImage advertImage);
    Task<AdvertImage> DeleteAsync(AdvertImage advertImage, bool permanent = false);
}
