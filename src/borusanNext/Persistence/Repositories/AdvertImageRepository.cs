using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AdvertImageRepository : EfRepositoryBase<AdvertImage, Guid, BaseDbContext>, IAdvertImageRepository
{
    private readonly BaseDbContext _baseDbContext;
    public AdvertImageRepository(BaseDbContext context) : base(context)
    {
        _baseDbContext = context;
    }

    public async Task<List<AdvertImage>> GetByAdvertId(Guid advertId)
    {
        var advertImages = _baseDbContext.Set<AdvertImage>();
        List<AdvertImage> images = await advertImages.Where(p => p.AdvertId == advertId).ToListAsync();

        return images;
    }
}