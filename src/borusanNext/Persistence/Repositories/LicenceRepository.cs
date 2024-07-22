using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LicenceRepository : EfRepositoryBase<Licence, Guid, BaseDbContext>, ILicenceRepository
{
    public LicenceRepository(BaseDbContext context) : base(context)
    {
    }
}