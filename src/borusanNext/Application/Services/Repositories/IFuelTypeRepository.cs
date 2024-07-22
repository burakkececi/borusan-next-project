using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFuelTypeRepository : IAsyncRepository<FuelType, Guid>, IRepository<FuelType, Guid>
{
}