using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBlogItemTagRepository : IAsyncRepository<BlogItemTag, Guid>, IRepository<BlogItemTag, Guid>
{
}