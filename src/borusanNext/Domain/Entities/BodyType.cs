using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class BodyType : Entity<Guid>
{
    public string BodyName { get; set; }
    public string Door { get; set; }

    public virtual ICollection<ModalExtension> ModalExtensions { get; set; }
}