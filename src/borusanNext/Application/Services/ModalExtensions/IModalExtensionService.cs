using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ModalExtensions;

public interface IModalExtensionService
{
    Task<ModalExtension?> GetAsync(
        Expression<Func<ModalExtension, bool>> predicate,
        Func<IQueryable<ModalExtension>, IIncludableQueryable<ModalExtension, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ModalExtension>?> GetListAsync(
        Expression<Func<ModalExtension, bool>>? predicate = null,
        Func<IQueryable<ModalExtension>, IOrderedQueryable<ModalExtension>>? orderBy = null,
        Func<IQueryable<ModalExtension>, IIncludableQueryable<ModalExtension, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ModalExtension> AddAsync(ModalExtension modalExtension);
    Task<ModalExtension> UpdateAsync(ModalExtension modalExtension);
    Task<ModalExtension> DeleteAsync(ModalExtension modalExtension, bool permanent = false);
}
