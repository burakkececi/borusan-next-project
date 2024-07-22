using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BlogItemTagRepository : EfRepositoryBase<BlogItemTag, Guid, BaseDbContext>, IBlogItemTagRepository
{
    public BlogItemTagRepository(BaseDbContext context) : base(context)
    {
    }
}