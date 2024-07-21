using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BlogItemTag : Entity<Guid>
{
    public Guid TagId { get; set; }
    public Guid BlogId { get; set; }
    public virtual Blog Blog { get; set; }
    public virtual Tag Tag { get; set; }
}
