using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CarModelRepository : EfRepositoryBase<CarModel, Guid, BaseDbContext>, ICarModelRepository
{
    public CarModelRepository(BaseDbContext context) : base(context)
    {
    }
}