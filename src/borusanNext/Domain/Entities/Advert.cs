using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Advert : Entity<Guid>
{
    public int AdvertNo { get; set; }
    public List<string> Photos { get; set; }
    public Guid CarId { get; set; }
    
    public virtual Car Car {get;set;}
    public virtual ICollection<CustomerAdvertLog> CustomerAdvertLogs { get; set; }
}
