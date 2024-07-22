using Application.Features.ExpertizeResults.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ExpertizeResults;

public class ExpertizeResultManager : IExpertizeResultService
{
    private readonly IExpertizeResultRepository _expertizeResultRepository;
    private readonly ExpertizeResultBusinessRules _expertizeResultBusinessRules;

    public ExpertizeResultManager(IExpertizeResultRepository expertizeResultRepository, ExpertizeResultBusinessRules expertizeResultBusinessRules)
    {
        _expertizeResultRepository = expertizeResultRepository;
        _expertizeResultBusinessRules = expertizeResultBusinessRules;
    }

    public async Task<ExpertizeResult?> GetAsync(
        Expression<Func<ExpertizeResult, bool>> predicate,
        Func<IQueryable<ExpertizeResult>, IIncludableQueryable<ExpertizeResult, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ExpertizeResult? expertizeResult = await _expertizeResultRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return expertizeResult;
    }

    public async Task<IPaginate<ExpertizeResult>?> GetListAsync(
        Expression<Func<ExpertizeResult, bool>>? predicate = null,
        Func<IQueryable<ExpertizeResult>, IOrderedQueryable<ExpertizeResult>>? orderBy = null,
        Func<IQueryable<ExpertizeResult>, IIncludableQueryable<ExpertizeResult, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ExpertizeResult> expertizeResultList = await _expertizeResultRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return expertizeResultList;
    }

    public async Task<ExpertizeResult> AddAsync(ExpertizeResult expertizeResult)
    {
        ExpertizeResult addedExpertizeResult = await _expertizeResultRepository.AddAsync(expertizeResult);

        return addedExpertizeResult;
    }

    public async Task<ExpertizeResult> UpdateAsync(ExpertizeResult expertizeResult)
    {
        ExpertizeResult updatedExpertizeResult = await _expertizeResultRepository.UpdateAsync(expertizeResult);

        return updatedExpertizeResult;
    }

    public async Task<ExpertizeResult> DeleteAsync(ExpertizeResult expertizeResult, bool permanent = false)
    {
        ExpertizeResult deletedExpertizeResult = await _expertizeResultRepository.DeleteAsync(expertizeResult);

        return deletedExpertizeResult;
    }
}
