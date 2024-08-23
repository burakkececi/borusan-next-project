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
    public Guid LicenceId { get; set; }
    public Guid LocationId { get; set; }

    public virtual Licence Licence { get; set; }
    public virtual Location Location { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<Car> Cars { get; set; }
}
