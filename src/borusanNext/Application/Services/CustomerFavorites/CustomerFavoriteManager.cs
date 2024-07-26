using Application.Features.CustomerFavorites.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerFavorites;

public class CustomerFavoriteManager : ICustomerFavoriteService
{
    private readonly ICustomerFavoriteRepository _customerFavoriteRepository;
    private readonly CustomerFavoriteBusinessRules _customerFavoriteBusinessRules;

    public CustomerFavoriteManager(ICustomerFavoriteRepository customerFavoriteRepository, CustomerFavoriteBusinessRules customerFavoriteBusinessRules)
    {
        _customerFavoriteRepository = customerFavoriteRepository;
        _customerFavoriteBusinessRules = customerFavoriteBusinessRules;
    }

    public async Task<CustomerFavorite?> GetAsync(
        Expression<Func<CustomerFavorite, bool>> predicate,
        Func<IQueryable<CustomerFavorite>, IIncludableQueryable<CustomerFavorite, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerFavorite? customerFavorite = await _customerFavoriteRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerFavorite;
    }

    public async Task<IPaginate<CustomerFavorite>?> GetListAsync(
        Expression<Func<CustomerFavorite, bool>>? predicate = null,
        Func<IQueryable<CustomerFavorite>, IOrderedQueryable<CustomerFavorite>>? orderBy = null,
        Func<IQueryable<CustomerFavorite>, IIncludableQueryable<CustomerFavorite, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerFavorite> customerFavoriteList = await _customerFavoriteRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerFavoriteList;
    }

    public async Task<CustomerFavorite> AddAsync(CustomerFavorite customerFavorite)
    {
        CustomerFavorite addedCustomerFavorite = await _customerFavoriteRepository.AddAsync(customerFavorite);

        return addedCustomerFavorite;
    }

    public async Task<CustomerFavorite> UpdateAsync(CustomerFavorite customerFavorite)
    {
        CustomerFavorite updatedCustomerFavorite = await _customerFavoriteRepository.UpdateAsync(customerFavorite);

        return updatedCustomerFavorite;
    }

    public async Task<CustomerFavorite> DeleteAsync(CustomerFavorite customerFavorite, bool permanent = false)
    {
        CustomerFavorite deletedCustomerFavorite = await _customerFavoriteRepository.DeleteAsync(customerFavorite);

        return deletedCustomerFavorite;
    }
}
