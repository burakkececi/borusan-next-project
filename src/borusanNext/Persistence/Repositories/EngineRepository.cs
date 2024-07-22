using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EngineRepository : EfRepositoryBase<Engine, Guid, BaseDbContext>, IEngineRepository
{
    public EngineRepository(BaseDbContext context) : base(context)
    {
    }
}