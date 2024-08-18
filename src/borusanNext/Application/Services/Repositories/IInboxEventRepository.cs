using Common.Models;
using System.Linq.Expressions;


namespace Application.Services.Repositories;
public interface IInboxEventRepository
{
    IQueryable<InboxEvent> GetAll();
    IQueryable<InboxEvent> GetWhere(Expression<Func<InboxEvent, bool>> method);
    Task AddAsync(InboxEvent model);
    Task SaveChangesAsync();
}
