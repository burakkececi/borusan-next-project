using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Transmission : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<ModalExtension> ModalExtensions { get; set; }

}