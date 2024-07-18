using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Seller : Entity<Guid>
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public Guid LicenceId { get; set; }
    public Guid LocaitonId { get; set; }
    public virtual Licence Licence { get; set; }
    public virtual Location Locaiton { get; set; }

}
