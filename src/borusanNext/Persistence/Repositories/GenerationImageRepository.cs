using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GenerationImageRepository : EfRepositoryBase<GenerationImage, Guid, BaseDbContext>, IGenerationImageRepository
{
    private readonly BaseDbContext _baseDbContext;
    public GenerationImageRepository(BaseDbContext context) : base(context)
    {
        _baseDbContext = context;
    }

    public async Task<List<GenerationImage>> GetByGenerationId(Guid generationId)
    {
        var generationImages = _baseDbContext.Set<GenerationImage>();
        List<GenerationImage> images = await generationImages.Where(p => p.GenerationId == generationId).ToListAsync();

        return images;
    }
}
