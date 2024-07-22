using Application.Features.BodyTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BodyTypes;

public class BodyTypeManager : IBodyTypeService
{
    private readonly IBodyTypeRepository _bodyTypeRepository;
    private readonly BodyTypeBusinessRules _bodyTypeBusinessRules;

    public BodyTypeManager(IBodyTypeRepository bodyTypeRepository, BodyTypeBusinessRules bodyTypeBusinessRules)
    {
        _bodyTypeRepository = bodyTypeRepository;
        _bodyTypeBusinessRules = bodyTypeBusinessRules;
    }

    public async Task<BodyType?> GetAsync(
        Expression<Func<BodyType, bool>> predicate,
        Func<IQueryable<BodyType>, IIncludableQueryable<BodyType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BodyType? bodyType = await _bodyTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bodyType;
    }

    public async Task<IPaginate<BodyType>?> GetListAsync(
        Expression<Func<BodyType, bool>>? predicate = null,
        Func<IQueryable<BodyType>, IOrderedQueryable<BodyType>>? orderBy = null,
        Func<IQueryable<BodyType>, IIncludableQueryable<BodyType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BodyType> bodyTypeList = await _bodyTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bodyTypeList;
    }

    public async Task<BodyType> AddAsync(BodyType bodyType)
    {
        BodyType addedBodyType = await _bodyTypeRepository.AddAsync(bodyType);

        return addedBodyType;
    }

    public async Task<BodyType> UpdateAsync(BodyType bodyType)
    {
        BodyType updatedBodyType = await _bodyTypeRepository.UpdateAsync(bodyType);

        return updatedBodyType;
    }

    public async Task<BodyType> DeleteAsync(BodyType bodyType, bool permanent = false)
    {
        BodyType deletedBodyType = await _bodyTypeRepository.DeleteAsync(bodyType);

        return deletedBodyType;
    }
}
