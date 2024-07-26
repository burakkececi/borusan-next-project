using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AdvertImageRepository : EfRepositoryBase<AdvertImage, Guid, BaseDbContext>, IAdvertImageRepository
{
    public AdvertImageRepository(BaseDbContext context) : base(context)
    {
    }
}