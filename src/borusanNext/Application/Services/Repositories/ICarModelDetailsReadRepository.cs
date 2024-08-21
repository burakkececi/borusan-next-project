using Application.Models;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories;
public interface ICarModelDetailsReadRepository
{
    CarModelDetailsReadModel? Get(Expression<Func<CarModelDetailsReadModel, bool>> predicate);
    IPaginate<CarModelDetailsReadModel> GetList(Expression<Func<CarModelDetailsReadModel, bool>>? predicate = null, Func<IQueryable<CarModelDetailsReadModel>, IOrderedQueryable<CarModelDetailsReadModel>>? orderBy = null, int index = 0, int size = 10);
    IPaginate<CarModelDetailsReadModel> GetListByDynamic(DynamicQuery dynamic, Expression<Func<CarModelDetailsReadModel, bool>>? predicate = null, int index = 0, int size = 10);

    Task<CarModelDetailsReadModel?> GetAsync(Expression<Func<CarModelDetailsReadModel, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IPaginate<CarModelDetailsReadModel>> GetListAsync(Expression<Func<CarModelDetailsReadModel, bool>>? predicate = null, Func<IQueryable<CarModelDetailsReadModel>, IOrderedQueryable<CarModelDetailsReadModel>>? orderBy = null, int index = 0, int size = 10, CancellationToken cancellationToken = default);
    Task<IPaginate<CarModelDetailsReadModel>> GetListByDynamicAsync(DynamicQuery dynamic, Expression<Func<CarModelDetailsReadModel, bool>>? predicate = null, int index = 0, int size = 10, CancellationToken cancellationToken = default);
}
