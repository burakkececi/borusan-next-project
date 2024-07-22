using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ModalExtensionRepository : EfRepositoryBase<ModalExtension, Guid, BaseDbContext>, IModalExtensionRepository
{
    public ModalExtensionRepository(BaseDbContext context) : base(context)
    {
    }
}