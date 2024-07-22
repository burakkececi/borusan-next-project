using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBodyShellPartRepository : IAsyncRepository<BodyShellPart, Guid>, IRepository<BodyShellPart, Guid>
{
}