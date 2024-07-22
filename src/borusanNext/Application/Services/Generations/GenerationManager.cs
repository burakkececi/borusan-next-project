using Application.Features.Generations.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Generations;

public class GenerationManager : IGenerationService
{
    private readonly IGenerationRepository _generationRepository;
    private readonly GenerationBusinessRules _generationBusinessRules;

    public GenerationManager(IGenerationRepository generationRepository, GenerationBusinessRules generationBusinessRules)
    {
        _generationRepository = generationRepository;
        _generationBusinessRules = generationBusinessRules;
    }

    public async Task<Generation?> GetAsync(
        Expression<Func<Generation, bool>> predicate,
        Func<IQueryable<Generation>, IIncludableQueryable<Generation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Generation? generation = await _generationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return generation;
    }

    public async Task<IPaginate<Generation>?> GetListAsync(
        Expression<Func<Generation, bool>>? predicate = null,
        Func<IQueryable<Generation>, IOrderedQueryable<Generation>>? orderBy = null,
        Func<IQueryable<Generation>, IIncludableQueryable<Generation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Generation> generationList = await _generationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return generationList;
    }

    public async Task<Generation> AddAsync(Generation generation)
    {
        Generation addedGeneration = await _generationRepository.AddAsync(generation);

        return addedGeneration;
    }

    public async Task<Generation> UpdateAsync(Generation generation)
    {
        Generation updatedGeneration = await _generationRepository.UpdateAsync(generation);

        return updatedGeneration;
    }

    public async Task<Generation> DeleteAsync(Generation generation, bool permanent = false)
    {
        Generation deletedGeneration = await _generationRepository.DeleteAsync(generation);

        return deletedGeneration;
    }
}
