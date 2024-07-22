using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerAdvertLogs;

public interface ICustomerAdvertLogService
{
    Task<CustomerAdvertLog?> GetAsync(
        Expression<Func<CustomerAdvertLog, bool>> predicate,
        Func<IQueryable<CustomerAdvertLog>, IIncludableQueryable<CustomerAdvertLog, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerAdvertLog>?> GetListAsync(
        Expression<Func<CustomerAdvertLog, bool>>? predicate = null,
        Func<IQueryable<CustomerAdvertLog>, IOrderedQueryable<CustomerAdvertLog>>? orderBy = null,
        Func<IQueryable<CustomerAdvertLog>, IIncludableQueryable<CustomerAdvertLog, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerAdvertLog> AddAsync(CustomerAdvertLog customerAdvertLog);
    Task<CustomerAdvertLog> UpdateAsync(CustomerAdvertLog customerAdvertLog);
    Task<CustomerAdvertLog> DeleteAsync(CustomerAdvertLog customerAdvertLog, bool permanent = false);
}
