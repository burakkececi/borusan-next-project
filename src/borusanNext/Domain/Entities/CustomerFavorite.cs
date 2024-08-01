using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class CustomerFavorite : Entity<Guid>
{
    public Guid CustomerId { get; set; }
    public Guid AdvertId { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual Advert Advert { get; set; }
}
