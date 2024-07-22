using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Licence : Entity<Guid>
{
    public int LicenceNo { get; set; }
    public string LicenceOwner { get; set; }

    public virtual Seller Seller { get; set; }

}
