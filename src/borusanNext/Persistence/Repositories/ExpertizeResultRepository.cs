using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ExpertizeResultRepository : EfRepositoryBase<ExpertizeResult, Guid, BaseDbContext>, IExpertizeResultRepository
{
    public ExpertizeResultRepository(BaseDbContext context) : base(context)
    {
    }
}