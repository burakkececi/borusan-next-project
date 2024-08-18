using Common.Models;
using NArchitecture.Core.Persistence.Repositories;
using System.Linq.Expressions;

namespace Application.Services.Repositories;
public interface IOutboxEventRepository
{
    IQueryable<OutboxEvent> GetAll();
    IQueryable<OutboxEvent> GetWhere(Expression<Func<OutboxEvent, bool>> method);
    Task AddAsync(OutboxEvent model);
    Task SaveChangesAsync();
}
