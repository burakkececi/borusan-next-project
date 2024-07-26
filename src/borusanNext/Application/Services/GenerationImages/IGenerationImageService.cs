using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.GenerationImages;

public interface IGenerationImageService
{
    Task<GenerationImage?> GetAsync(
        Expression<Func<GenerationImage, bool>> predicate,
        Func<IQueryable<GenerationImage>, IIncludableQueryable<GenerationImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<GenerationImage>?> GetListAsync(
        Expression<Func<GenerationImage, bool>>? predicate = null,
        Func<IQueryable<GenerationImage>, IOrderedQueryable<GenerationImage>>? orderBy = null,
        Func<IQueryable<GenerationImage>, IIncludableQueryable<GenerationImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<GenerationImage> AddAsync(GenerationImage generationImage);
    Task<GenerationImage> UpdateAsync(GenerationImage generationImage);
    Task<GenerationImage> DeleteAsync(GenerationImage generationImage, bool permanent = false);
}
