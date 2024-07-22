using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BodyTypeRepository : EfRepositoryBase<BodyType, Guid, BaseDbContext>, IBodyTypeRepository
{
    public BodyTypeRepository(BaseDbContext context) : base(context)
    {
    }
}