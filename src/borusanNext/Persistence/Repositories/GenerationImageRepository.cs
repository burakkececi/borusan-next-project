using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GenerationImageRepository : EfRepositoryBase<GenerationImage, Guid, BaseDbContext>, IGenerationImageRepository
{
    public GenerationImageRepository(BaseDbContext context) : base(context)
    {
    }
}