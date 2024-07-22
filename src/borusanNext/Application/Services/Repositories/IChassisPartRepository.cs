using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IChassisPartRepository : IAsyncRepository<ChassisPart, Guid>, IRepository<ChassisPart, Guid>
{
}