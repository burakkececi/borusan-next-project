using Application.Features.ModalExtensions.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ModalExtensions;

public class ModalExtensionManager : IModalExtensionService
{
    private readonly IModalExtensionRepository _modalExtensionRepository;
    private readonly ModalExtensionBusinessRules _modalExtensionBusinessRules;

    public ModalExtensionManager(IModalExtensionRepository modalExtensionRepository, ModalExtensionBusinessRules modalExtensionBusinessRules)
    {
        _modalExtensionRepository = modalExtensionRepository;
        _modalExtensionBusinessRules = modalExtensionBusinessRules;
    }

    public async Task<ModalExtension?> GetAsync(
        Expression<Func<ModalExtension, bool>> predicate,
        Func<IQueryable<ModalExtension>, IIncludableQueryable<ModalExtension, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ModalExtension? modalExtension = await _modalExtensionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return modalExtension;
    }

    public async Task<IPaginate<ModalExtension>?> GetListAsync(
        Expression<Func<ModalExtension, bool>>? predicate = null,
        Func<IQueryable<ModalExtension>, IOrderedQueryable<ModalExtension>>? orderBy = null,
        Func<IQueryable<ModalExtension>, IIncludableQueryable<ModalExtension, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ModalExtension> modalExtensionList = await _modalExtensionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return modalExtensionList;
    }

    public async Task<ModalExtension> AddAsync(ModalExtension modalExtension)
    {
        ModalExtension addedModalExtension = await _modalExtensionRepository.AddAsync(modalExtension);

        return addedModalExtension;
    }

    public async Task<ModalExtension> UpdateAsync(ModalExtension modalExtension)
    {
        ModalExtension updatedModalExtension = await _modalExtensionRepository.UpdateAsync(modalExtension);

        return updatedModalExtension;
    }

    public async Task<ModalExtension> DeleteAsync(ModalExtension modalExtension, bool permanent = false)
    {
        ModalExtension deletedModalExtension = await _modalExtensionRepository.DeleteAsync(modalExtension);

        return deletedModalExtension;
    }
}
