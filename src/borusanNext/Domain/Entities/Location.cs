using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Location : Entity<Guid>
{
    public string Name { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public decimal Latitute { get; set; }
    public decimal Longitute { get; set; }
}
