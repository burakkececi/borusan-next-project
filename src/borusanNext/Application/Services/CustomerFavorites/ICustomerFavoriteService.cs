using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerFavorites;

public interface ICustomerFavoriteService
{
    Task<CustomerFavorite?> GetAsync(
        Expression<Func<CustomerFavorite, bool>> predicate,
        Func<IQueryable<CustomerFavorite>, IIncludableQueryable<CustomerFavorite, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerFavorite>?> GetListAsync(
        Expression<Func<CustomerFavorite, bool>>? predicate = null,
        Func<IQueryable<CustomerFavorite>, IOrderedQueryable<CustomerFavorite>>? orderBy = null,
        Func<IQueryable<CustomerFavorite>, IIncludableQueryable<CustomerFavorite, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerFavorite> AddAsync(CustomerFavorite customerFavorite);
    Task<CustomerFavorite> UpdateAsync(CustomerFavorite customerFavorite);
    Task<CustomerFavorite> DeleteAsync(CustomerFavorite customerFavorite, bool permanent = false);
}
