using Application.Features.BodyShellParts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BodyShellParts;

public class BodyShellPartManager : IBodyShellPartService
{
    private readonly IBodyShellPartRepository _bodyShellPartRepository;
    private readonly BodyShellPartBusinessRules _bodyShellPartBusinessRules;

    public BodyShellPartManager(IBodyShellPartRepository bodyShellPartRepository, BodyShellPartBusinessRules bodyShellPartBusinessRules)
    {
        _bodyShellPartRepository = bodyShellPartRepository;
        _bodyShellPartBusinessRules = bodyShellPartBusinessRules;
    }

    public async Task<BodyShellPart?> GetAsync(
        Expression<Func<BodyShellPart, bool>> predicate,
        Func<IQueryable<BodyShellPart>, IIncludableQueryable<BodyShellPart, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BodyShellPart? bodyShellPart = await _bodyShellPartRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bodyShellPart;
    }

    public async Task<IPaginate<BodyShellPart>?> GetListAsync(
        Expression<Func<BodyShellPart, bool>>? predicate = null,
        Func<IQueryable<BodyShellPart>, IOrderedQueryable<BodyShellPart>>? orderBy = null,
        Func<IQueryable<BodyShellPart>, IIncludableQueryable<BodyShellPart, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BodyShellPart> bodyShellPartList = await _bodyShellPartRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bodyShellPartList;
    }

    public async Task<BodyShellPart> AddAsync(BodyShellPart bodyShellPart)
    {
        BodyShellPart addedBodyShellPart = await _bodyShellPartRepository.AddAsync(bodyShellPart);

        return addedBodyShellPart;
    }

    public async Task<BodyShellPart> UpdateAsync(BodyShellPart bodyShellPart)
    {
        BodyShellPart updatedBodyShellPart = await _bodyShellPartRepository.UpdateAsync(bodyShellPart);

        return updatedBodyShellPart;
    }

    public async Task<BodyShellPart> DeleteAsync(BodyShellPart bodyShellPart, bool permanent = false)
    {
        BodyShellPart deletedBodyShellPart = await _bodyShellPartRepository.DeleteAsync(bodyShellPart);

        return deletedBodyShellPart;
    }
}
