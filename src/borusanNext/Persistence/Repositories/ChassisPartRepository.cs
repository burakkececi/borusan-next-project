using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ChassisPartRepository : EfRepositoryBase<ChassisPart, Guid, BaseDbContext>, IChassisPartRepository
{
    public ChassisPartRepository(BaseDbContext context) : base(context)
    {
    }
}