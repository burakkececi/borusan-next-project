using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CarRepository : EfRepositoryBase<Car, Guid, BaseDbContext>, ICarRepository
{
    public CarRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<List<Car>> GetCarsByKilometersAsync(int maxKilometers)
    {
        return await _context.Cars
           .Where(car => car.Kilometers <= maxKilometers)
           .ToListAsync();
    }
}