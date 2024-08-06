using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Location : Entity<Guid>
{
    public string City { get; set; }
    public string Address { get; set; }
    public string Latitute { get; set; }
    public string Longitute { get; set; }

    public virtual Seller Seller { get; set; }
}
