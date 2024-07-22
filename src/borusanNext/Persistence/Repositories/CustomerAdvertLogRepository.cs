using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomerAdvertLogRepository : EfRepositoryBase<CustomerAdvertLog, Guid, BaseDbContext>, ICustomerAdvertLogRepository
{
    public CustomerAdvertLogRepository(BaseDbContext context) : base(context)
    {
    }
}