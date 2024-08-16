using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGenerationImageRepository : IAsyncRepository<GenerationImage, Guid>, IRepository<GenerationImage, Guid>
{
    public Task<List<GenerationImage>> GetByGenerationId(Guid generationId);
}