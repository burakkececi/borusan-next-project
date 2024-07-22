using Application.Features.ChassisParts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ChassisParts;

public class ChassisPartManager : IChassisPartService
{
    private readonly IChassisPartRepository _chassisPartRepository;
    private readonly ChassisPartBusinessRules _chassisPartBusinessRules;

    public ChassisPartManager(IChassisPartRepository chassisPartRepository, ChassisPartBusinessRules chassisPartBusinessRules)
    {
        _chassisPartRepository = chassisPartRepository;
        _chassisPartBusinessRules = chassisPartBusinessRules;
    }

    public async Task<ChassisPart?> GetAsync(
        Expression<Func<ChassisPart, bool>> predicate,
        Func<IQueryable<ChassisPart>, IIncludableQueryable<ChassisPart, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ChassisPart? chassisPart = await _chassisPartRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return chassisPart;
    }

    public async Task<IPaginate<ChassisPart>?> GetListAsync(
        Expression<Func<ChassisPart, bool>>? predicate = null,
        Func<IQueryable<ChassisPart>, IOrderedQueryable<ChassisPart>>? orderBy = null,
        Func<IQueryable<ChassisPart>, IIncludableQueryable<ChassisPart, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ChassisPart> chassisPartList = await _chassisPartRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return chassisPartList;
    }

    public async Task<ChassisPart> AddAsync(ChassisPart chassisPart)
    {
        ChassisPart addedChassisPart = await _chassisPartRepository.AddAsync(chassisPart);

        return addedChassisPart;
    }

    public async Task<ChassisPart> UpdateAsync(ChassisPart chassisPart)
    {
        ChassisPart updatedChassisPart = await _chassisPartRepository.UpdateAsync(chassisPart);

        return updatedChassisPart;
    }

    public async Task<ChassisPart> DeleteAsync(ChassisPart chassisPart, bool permanent = false)
    {
        ChassisPart deletedChassisPart = await _chassisPartRepository.DeleteAsync(chassisPart);

        return deletedChassisPart;
    }
}
