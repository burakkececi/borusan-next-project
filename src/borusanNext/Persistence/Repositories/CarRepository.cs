using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CarRepository : EfRepositoryBase<Car, Guid, BaseDbContext>, ICarRepository
{
    private readonly BaseDbContext _baseDbContext;
    public CarRepository(BaseDbContext context, BaseDbContext baseDbContext) : base(context)
    {
        _baseDbContext = baseDbContext;
    }

    public async Task<List<Car>> GetCarsByKilometersAsync(int maxKilometers)
    {
        return await _baseDbContext.Cars
           .Where(car => car.Kilometers <= maxKilometers)
           .ToListAsync();
    }
}