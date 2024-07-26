using Application.Features.AdvertImages.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AdvertImages;

public class AdvertImageManager : IAdvertImageService
{
    private readonly IAdvertImageRepository _advertImageRepository;
    private readonly AdvertImageBusinessRules _advertImageBusinessRules;

    public AdvertImageManager(IAdvertImageRepository advertImageRepository, AdvertImageBusinessRules advertImageBusinessRules)
    {
        _advertImageRepository = advertImageRepository;
        _advertImageBusinessRules = advertImageBusinessRules;
    }

    public async Task<AdvertImage?> GetAsync(
        Expression<Func<AdvertImage, bool>> predicate,
        Func<IQueryable<AdvertImage>, IIncludableQueryable<AdvertImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AdvertImage? advertImage = await _advertImageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return advertImage;
    }

    public async Task<IPaginate<AdvertImage>?> GetListAsync(
        Expression<Func<AdvertImage, bool>>? predicate = null,
        Func<IQueryable<AdvertImage>, IOrderedQueryable<AdvertImage>>? orderBy = null,
        Func<IQueryable<AdvertImage>, IIncludableQueryable<AdvertImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AdvertImage> advertImageList = await _advertImageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return advertImageList;
    }

    public async Task<AdvertImage> AddAsync(AdvertImage advertImage)
    {
        AdvertImage addedAdvertImage = await _advertImageRepository.AddAsync(advertImage);

        return addedAdvertImage;
    }

    public async Task<AdvertImage> UpdateAsync(AdvertImage advertImage)
    {
        AdvertImage updatedAdvertImage = await _advertImageRepository.UpdateAsync(advertImage);

        return updatedAdvertImage;
    }

    public async Task<AdvertImage> DeleteAsync(AdvertImage advertImage, bool permanent = false)
    {
        AdvertImage deletedAdvertImage = await _advertImageRepository.DeleteAsync(advertImage);

        return deletedAdvertImage;
    }
}
