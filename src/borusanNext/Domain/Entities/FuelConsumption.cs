using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class FuelConsumption : Entity<Guid>
{
    public double OutOfTown { get; set; }
    public double Urban { get; set; }
    public double Average { get; set; }

    public virtual Engine Engine { get; set; }

}