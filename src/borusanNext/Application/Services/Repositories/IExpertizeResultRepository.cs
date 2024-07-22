using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IExpertizeResultRepository : IAsyncRepository<ExpertizeResult, Guid>, IRepository<ExpertizeResult, Guid>
{
}