using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class BodyType : Entity<Guid>
{
    public string BodyName { get; set; }
    public int Door { get; set; }

    public virtual CarModel CarModel { get; set; }
}