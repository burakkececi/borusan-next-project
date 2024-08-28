using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Address : Entity<Guid>
{
    public string City { get; set; }
    public string District { get; set; }

    public virtual ICollection<Seller> Sellers { get; set; }
    public virtual ICollection<Customer> Customers { get; set; }
}
