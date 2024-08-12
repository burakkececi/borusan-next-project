using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Advert : Entity<Guid>
{
    public int AdvertNo { get; set; }
    public Guid CarId { get; set; }
    
    public virtual Car Car {get;set;}
    public virtual ICollection<CustomerAdvertLog> CustomerAdvertLogs { get; set; }
    public virtual ICollection<AdvertImage> AdvertImages { get; set; }
    public virtual ICollection<CustomerFavorite> CustomerFavorites { get; set; }

}
