using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FuelTypeRepository : EfRepositoryBase<FuelType, Guid, BaseDbContext>, IFuelTypeRepository
{
    public FuelTypeRepository(BaseDbContext context) : base(context)
    {
    }
}