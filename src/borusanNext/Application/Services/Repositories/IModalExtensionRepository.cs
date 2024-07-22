using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IModalExtensionRepository : IAsyncRepository<ModalExtension, Guid>, IRepository<ModalExtension, Guid>
{
}