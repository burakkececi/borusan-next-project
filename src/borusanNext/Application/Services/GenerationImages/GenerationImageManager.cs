using Application.Features.GenerationImages.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.GenerationImages;

public class GenerationImageManager : IGenerationImageService
{
    private readonly IGenerationImageRepository _generationImageRepository;
    private readonly GenerationImageBusinessRules _generationImageBusinessRules;

    public GenerationImageManager(IGenerationImageRepository generationImageRepository, GenerationImageBusinessRules generationImageBusinessRules)
    {
        _generationImageRepository = generationImageRepository;
        _generationImageBusinessRules = generationImageBusinessRules;
    }

    public async Task<GenerationImage?> GetAsync(
        Expression<Func<GenerationImage, bool>> predicate,
        Func<IQueryable<GenerationImage>, IIncludableQueryable<GenerationImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        GenerationImage? generationImage = await _generationImageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return generationImage;
    }

    public async Task<IPaginate<GenerationImage>?> GetListAsync(
        Expression<Func<GenerationImage, bool>>? predicate = null,
        Func<IQueryable<GenerationImage>, IOrderedQueryable<GenerationImage>>? orderBy = null,
        Func<IQueryable<GenerationImage>, IIncludableQueryable<GenerationImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<GenerationImage> generationImageList = await _generationImageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return generationImageList;
    }

    public async Task<GenerationImage> AddAsync(GenerationImage generationImage)
    {
        GenerationImage addedGenerationImage = await _generationImageRepository.AddAsync(generationImage);

        return addedGenerationImage;
    }

    public async Task<GenerationImage> UpdateAsync(GenerationImage generationImage)
    {
        GenerationImage updatedGenerationImage = await _generationImageRepository.UpdateAsync(generationImage);

        return updatedGenerationImage;
    }

    public async Task<GenerationImage> DeleteAsync(GenerationImage generationImage, bool permanent = false)
    {
        GenerationImage deletedGenerationImage = await _generationImageRepository.DeleteAsync(generationImage);

        return deletedGenerationImage;
    }
}
