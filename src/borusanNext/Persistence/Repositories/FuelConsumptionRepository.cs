using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FuelConsumptionRepository : EfRepositoryBase<FuelConsumption, Guid, BaseDbContext>, IFuelConsumptionRepository
{
    public FuelConsumptionRepository(BaseDbContext context) : base(context)
    {
    }
}