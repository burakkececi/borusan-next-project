using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BodyShellPartRepository : EfRepositoryBase<BodyShellPart, Guid, BaseDbContext>, IBodyShellPartRepository
{
    public BodyShellPartRepository(BaseDbContext context) : base(context)
    {
    }
}