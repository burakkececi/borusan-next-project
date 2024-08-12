using Application.Models;
using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories;
public class AdvertDetailsReadRepository : IAdvertDetailsReadRepository
{
    protected readonly BaseDbContext Context;

    private IQueryable<AdvertDetailsReadModel> Query() => Context.Set<AdvertDetailsReadModel>();
    
    public AdvertDetailsReadRepository(BaseDbContext context)
    {
        Context = context;
    }

    public AdvertDetailsReadModel? Get(Expression<Func<AdvertDetailsReadModel, bool>> predicate)
    {
        IQueryable<AdvertDetailsReadModel> queryable = Query();
        return queryable.FirstOrDefault(predicate);
    }

    public async Task<AdvertDetailsReadModel?> GetAsync(Expression<Func<AdvertDetailsReadModel, bool>> predicate, CancellationToken cancellationToken = default)
    {
        IQueryable<AdvertDetailsReadModel> queryable = Query();
        return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(queryable, predicate, cancellationToken);
    }

    public IPaginate<AdvertDetailsReadModel> GetList(Expression<Func<AdvertDetailsReadModel, bool>>? predicate = null, Func<IQueryable<AdvertDetailsReadModel>, IOrderedQueryable<AdvertDetailsReadModel>>? orderBy = null, int index = 0, int size = 10)
    {
        IQueryable<AdvertDetailsReadModel> queryable = Query();

        if (predicate != null)
        {
            queryable = queryable.Where(predicate);
        }

        if (orderBy != null)
        {
            return orderBy(queryable).ToPaginate(index, size);
        }

        return queryable.ToPaginate(index, size);
    }

    public async Task<IPaginate<AdvertDetailsReadModel>> GetListAsync(Expression<Func<AdvertDetailsReadModel, bool>>? predicate = null, Func<IQueryable<AdvertDetailsReadModel>, IOrderedQueryable<AdvertDetailsReadModel>>? orderBy = null, int index = 0, int size = 10, CancellationToken cancellationToken = default)
    {
        IQueryable<AdvertDetailsReadModel> queryable = Query();

        if (predicate != null)
        {
            queryable = queryable.Where(predicate);
        }

        if (orderBy != null)
        {
            return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
        }

        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }

    public IPaginate<AdvertDetailsReadModel> GetListByDynamic(DynamicQuery dynamic, Expression<Func<AdvertDetailsReadModel, bool>>? predicate = null, int index = 0, int size = 10)
    {

        IQueryable<AdvertDetailsReadModel> queryable = Query().ToDynamic(dynamic);

        if (predicate != null)
        {
            queryable = queryable.Where(predicate);
        }

        return queryable.ToPaginate(index, size);
    }

    public async Task<IPaginate<AdvertDetailsReadModel>> GetListByDynamicAsync(DynamicQuery dynamic, Expression<Func<AdvertDetailsReadModel, bool>>? predicate = null, int index = 0, int size = 10, CancellationToken cancellationToken = default)
    {
        IQueryable<AdvertDetailsReadModel> queryable = Query().ToDynamic(dynamic);

        if (predicate != null)
        {
            queryable = queryable.Where(predicate);
        }

        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }
}
