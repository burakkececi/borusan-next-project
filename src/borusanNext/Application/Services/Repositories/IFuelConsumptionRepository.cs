using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFuelConsumptionRepository : IAsyncRepository<FuelConsumption, Guid>, IRepository<FuelConsumption, Guid>
{
}