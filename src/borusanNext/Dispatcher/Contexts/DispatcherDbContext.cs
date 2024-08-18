using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace OutboxJobService.Contexts;
public class DispatcherDbContext : DbContext
{
    public DbSet<OutboxEvent> OutboxEvents { get; set; }
    public DispatcherDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OutboxEvent>().ToTable("OutboxEvents", schema: "event");
        base.OnModelCreating(modelBuilder);
    }

}
