using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class FuelType : Entity<Guid>
{
    public string Name { get; set; } // dizel, motorin
    public virtual Engine Engine { get; set; }
}