using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projections.UserService.Contexts;
public class ProjectionsUserDbContext : DbContext
{
    public DbSet<InboxEvent> InboxEvents { get; set; }
    public ProjectionsUserDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InboxEvent>().ToTable("InboxEvents", schema: "event");
        base.OnModelCreating(modelBuilder);
    }
}
