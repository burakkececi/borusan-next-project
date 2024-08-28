using NArchitecture.Core.Persistence.Repositories;
using NArchitecture.Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Seller : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public Guid AddressId { get; set; }
    public string AddressLine { get; set; }
    public string Latitute { get; set; }
    public string Longitute { get; set; }
    public int LicenceNo { get; set; }
    public string ProvidedBy { get; set; }

    public virtual User User { get; set; }
    public virtual Address Address { get; set; }
    public virtual ICollection<Car> Cars { get; set; }
}
