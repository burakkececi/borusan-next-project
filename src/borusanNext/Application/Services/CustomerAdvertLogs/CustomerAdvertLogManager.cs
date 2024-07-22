using Application.Features.CustomerAdvertLogs.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerAdvertLogs;

public class CustomerAdvertLogManager : ICustomerAdvertLogService
{
    private readonly ICustomerAdvertLogRepository _customerAdvertLogRepository;
    private readonly CustomerAdvertLogBusinessRules _customerAdvertLogBusinessRules;

    public CustomerAdvertLogManager(ICustomerAdvertLogRepository customerAdvertLogRepository, CustomerAdvertLogBusinessRules customerAdvertLogBusinessRules)
    {
        _customerAdvertLogRepository = customerAdvertLogRepository;
        _customerAdvertLogBusinessRules = customerAdvertLogBusinessRules;
    }

    public async Task<CustomerAdvertLog?> GetAsync(
        Expression<Func<CustomerAdvertLog, bool>> predicate,
        Func<IQueryable<CustomerAdvertLog>, IIncludableQueryable<CustomerAdvertLog, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerAdvertLog? customerAdvertLog = await _customerAdvertLogRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerAdvertLog;
    }

    public async Task<IPaginate<CustomerAdvertLog>?> GetListAsync(
        Expression<Func<CustomerAdvertLog, bool>>? predicate = null,
        Func<IQueryable<CustomerAdvertLog>, IOrderedQueryable<CustomerAdvertLog>>? orderBy = null,
        Func<IQueryable<CustomerAdvertLog>, IIncludableQueryable<CustomerAdvertLog, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerAdvertLog> customerAdvertLogList = await _customerAdvertLogRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerAdvertLogList;
    }

    public async Task<CustomerAdvertLog> AddAsync(CustomerAdvertLog customerAdvertLog)
    {
        CustomerAdvertLog addedCustomerAdvertLog = await _customerAdvertLogRepository.AddAsync(customerAdvertLog);

        return addedCustomerAdvertLog;
    }

    public async Task<CustomerAdvertLog> UpdateAsync(CustomerAdvertLog customerAdvertLog)
    {
        CustomerAdvertLog updatedCustomerAdvertLog = await _customerAdvertLogRepository.UpdateAsync(customerAdvertLog);

        return updatedCustomerAdvertLog;
    }

    public async Task<CustomerAdvertLog> DeleteAsync(CustomerAdvertLog customerAdvertLog, bool permanent = false)
    {
        CustomerAdvertLog deletedCustomerAdvertLog = await _customerAdvertLogRepository.DeleteAsync(customerAdvertLog);

        return deletedCustomerAdvertLog;
    }
}
