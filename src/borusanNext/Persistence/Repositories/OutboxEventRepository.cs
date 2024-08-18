using Application.Services.Repositories;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories;
public class OutboxEventRepository : IOutboxEventRepository
{
    readonly BaseDbContext _context;
    public OutboxEventRepository(BaseDbContext context)
    {
        this._context = context;
    }

    public DbSet<OutboxEvent> Table { get => _context.Set<OutboxEvent>(); }

    public async Task AddAsync(OutboxEvent model)
          => await Table.AddAsync(model);

    public IQueryable<OutboxEvent> GetAll()
        => Table;

    public IQueryable<OutboxEvent> GetWhere(Expression<Func<OutboxEvent, bool>> method)
        => Table.Where(method);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}
