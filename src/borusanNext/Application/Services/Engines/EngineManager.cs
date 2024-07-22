using Application.Features.Engines.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Engines;

public class EngineManager : IEngineService
{
    private readonly IEngineRepository _engineRepository;
    private readonly EngineBusinessRules _engineBusinessRules;

    public EngineManager(IEngineRepository engineRepository, EngineBusinessRules engineBusinessRules)
    {
        _engineRepository = engineRepository;
        _engineBusinessRules = engineBusinessRules;
    }

    public async Task<Engine?> GetAsync(
        Expression<Func<Engine, bool>> predicate,
        Func<IQueryable<Engine>, IIncludableQueryable<Engine, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Engine? engine = await _engineRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return engine;
    }

    public async Task<IPaginate<Engine>?> GetListAsync(
        Expression<Func<Engine, bool>>? predicate = null,
        Func<IQueryable<Engine>, IOrderedQueryable<Engine>>? orderBy = null,
        Func<IQueryable<Engine>, IIncludableQueryable<Engine, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Engine> engineList = await _engineRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return engineList;
    }

    public async Task<Engine> AddAsync(Engine engine)
    {
        Engine addedEngine = await _engineRepository.AddAsync(engine);

        return addedEngine;
    }

    public async Task<Engine> UpdateAsync(Engine engine)
    {
        Engine updatedEngine = await _engineRepository.UpdateAsync(engine);

        return updatedEngine;
    }

    public async Task<Engine> DeleteAsync(Engine engine, bool permanent = false)
    {
        Engine deletedEngine = await _engineRepository.DeleteAsync(engine);

        return deletedEngine;
    }
}
