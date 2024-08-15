using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAdvertImageRepository : IAsyncRepository<AdvertImage, Guid>, IRepository<AdvertImage, Guid>
{
    public Task<List<AdvertImage>> GetByAdvertId(Guid advertId);
}