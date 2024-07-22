using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerAdvertLogRepository : IAsyncRepository<CustomerAdvertLog, Guid>, IRepository<CustomerAdvertLog, Guid>
{
}