using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBodyTypeRepository : IAsyncRepository<BodyType, Guid>, IRepository<BodyType, Guid>
{
}