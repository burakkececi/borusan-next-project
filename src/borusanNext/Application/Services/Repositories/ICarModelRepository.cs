using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICarModelRepository : IAsyncRepository<CarModel, Guid>, IRepository<CarModel, Guid>
{
}