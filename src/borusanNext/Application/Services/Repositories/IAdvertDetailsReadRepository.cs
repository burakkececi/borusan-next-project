using Application.Models;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using System.Linq.Expressions;

namespace Application.Services.Repositories;
public interface IAdvertDetailsReadRepository
{
    AdvertDetailsReadModel? Get(Expression<Func<AdvertDetailsReadModel, bool>> predicate);
    IPaginate<AdvertDetailsReadModel> GetList(Expression<Func<AdvertDetailsReadModel, bool>>? predicate = null, Func<IQueryable<AdvertDetailsReadModel>, IOrderedQueryable<AdvertDetailsReadModel>>? orderBy = null, int index = 0, int size = 10);
    IPaginate<AdvertDetailsReadModel> GetListByDynamic(DynamicQuery dynamic, Expression<Func<AdvertDetailsReadModel, bool>>? predicate = null, int index = 0, int size = 10);
    
    Task<AdvertDetailsReadModel?> GetAsync(Expression<Func<AdvertDetailsReadModel, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IPaginate<AdvertDetailsReadModel>> GetListAsync(Expression<Func<AdvertDetailsReadModel, bool>>? predicate = null, Func<IQueryable<AdvertDetailsReadModel>, IOrderedQueryable<AdvertDetailsReadModel>>? orderBy = null, int index = 0, int size = 10, CancellationToken cancellationToken = default);
    Task<IPaginate<AdvertDetailsReadModel>> GetListByDynamicAsync(DynamicQuery dynamic, Expression<Func<AdvertDetailsReadModel, bool>>? predicate = null, int index = 0, int size = 10, CancellationToken cancellationToken = default);

}
