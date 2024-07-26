using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class GenerationImage : Entity<Guid>
{
    public Guid GenerationId { get; set; }
    public string ImageURL { get; set; }

    public virtual Generation Generation { get; set; }
}
