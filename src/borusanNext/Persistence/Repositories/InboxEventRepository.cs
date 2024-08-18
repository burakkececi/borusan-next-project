using Application.Services.Repositories;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;


namespace Persistence.Repositories;
public class InboxEventRepository : IInboxEventRepository
{
    readonly BaseDbContext _context;
    public InboxEventRepository(BaseDbContext context)
    {
        this._context = context;
    }

    public DbSet<InboxEvent> Table { get => _context.Set<InboxEvent>(); }

    public async Task AddAsync(InboxEvent model)
          => await Table.AddAsync(model);

    public IQueryable<InboxEvent> GetAll()
        => Table;

    public IQueryable<InboxEvent> GetWhere(Expression<Func<InboxEvent, bool>> method)
        => Table.Where(method);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}
