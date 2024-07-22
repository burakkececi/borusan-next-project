using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class BodyType : Entity<Guid>
{
    public Guid BodyName { get; set; }
    public string Door { get; set; }

    public virtual ICollection<Car> Cars { get; set; }
}