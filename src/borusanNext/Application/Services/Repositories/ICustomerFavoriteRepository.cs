using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerFavoriteRepository : IAsyncRepository<CustomerFavorite, Guid>, IRepository<CustomerFavorite, Guid>
{
}