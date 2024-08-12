using System.Diagnostics;
using System.Reflection;
using Application.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Advert> Adverts { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogItemTag> BlogItemTags { get; set; }
    public DbSet<BodyShellPart> BodyShellParts { get; set; }
    public DbSet<BodyType> BodyTypes { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarColor> CarColors { get; set; }
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<ChassisPart> ChassisParts { get; set; }
    public DbSet<CustomerAdvertLog> CustomerAdvertLogs { get; set; }
    public DbSet<Engine> Engines { get; set; }
    public DbSet<ExpertizeResult> ExpertizeResults { get; set; }
    public DbSet<FuelType> FuelTypes { get; set; }
    public DbSet<Generation> Generations { get; set; }
    public DbSet<Licence> Licences { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<ModalExtension> ModalExtensions { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<AdvertImage> AdvertImages { get; set; }
    public DbSet<GenerationImage> GenerationImages { get; set; }
    public DbSet<CustomerFavorite> CustomerFavorites { get; set; }
    public DbSet<AdvertDetailsReadModel> AdvertDetails { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .LogTo(message => Debug.WriteLine(message))
            .EnableSensitiveDataLogging();

        base.OnConfiguring(optionsBuilder);
    }
}
