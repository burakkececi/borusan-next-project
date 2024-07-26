using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerFavoriteRepository : EfRepositoryBase<CustomerFavorite, Guid, BaseDbContext>, ICustomerFavoriteRepository
{
    public CustomerFavoriteRepository(BaseDbContext context) : base(context)
    {
    }
}