using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILicenceRepository : IAsyncRepository<Licence, Guid>, IRepository<Licence, Guid>
{
}