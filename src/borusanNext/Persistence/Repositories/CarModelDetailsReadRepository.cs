using Application.Models;
using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class CarModelDetailsReadRepository : ICarModelDetailsReadRepository
{
    protected readonly BaseDbContext Context;

    private IQueryable<CarModelDetailsReadModel> Query() => Context.Set<CarModelDetailsReadModel>();

    public CarModelDetailsReadRepository(BaseDbContext context)
    {
        Context = context;
    }

    public CarModelDetailsReadModel? Get(Expression<Func<CarModelDetailsReadModel, bool>> predicate)
    {
        IQueryable<CarModelDetailsReadModel> queryable = Query();
        return queryable.FirstOrDefault(predicate);
    }

    public async Task<CarModelDetailsReadModel?> GetAsync(Expression<Func<CarModelDetailsReadModel, bool>> predicate, CancellationToken cancellationToken = default)
    {
        IQueryable<CarModelDetailsReadModel> queryable = Query();
        return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(queryable, predicate, cancellationToken);
    }

    public IPaginate<CarModelDetailsReadModel> GetList(Expression<Func<CarModelDetailsReadModel, bool>>? predicate = null, Func<IQueryable<CarModelDetailsReadModel>, IOrderedQueryable<CarModelDetailsReadModel>>? orderBy = null, int index = 0, int size = 10)
    {
        IQueryable<CarModelDetailsReadModel> queryable = Query();

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

    public async Task<IPaginate<CarModelDetailsReadModel>> GetListAsync(Expression<Func<CarModelDetailsReadModel, bool>>? predicate = null, Func<IQueryable<CarModelDetailsReadModel>, IOrderedQueryable<CarModelDetailsReadModel>>? orderBy = null, int index = 0, int size = 10, CancellationToken cancellationToken = default)
    {
        IQueryable<CarModelDetailsReadModel> queryable = Query();

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

    public IPaginate<CarModelDetailsReadModel> GetListByDynamic(DynamicQuery dynamic, Expression<Func<CarModelDetailsReadModel, bool>>? predicate = null, int index = 0, int size = 10)
    {

        IQueryable<CarModelDetailsReadModel> queryable = Query().ToDynamic(dynamic);

        if (predicate != null)
        {
            queryable = queryable.Where(predicate);
        }

        return queryable.ToPaginate(index, size);
    }

    public async Task<IPaginate<CarModelDetailsReadModel>> GetListByDynamicAsync(DynamicQuery dynamic, Expression<Func<CarModelDetailsReadModel, bool>>? predicate = null, int index = 0, int size = 10, CancellationToken cancellationToken = default)
    {
        IQueryable<CarModelDetailsReadModel> queryable = Query().ToDynamic(dynamic);

        if (predicate != null)
        {
            queryable = queryable.Where(predicate);
        }

        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }
}
