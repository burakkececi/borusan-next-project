using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Appointment : Entity<Guid>
{
    public DateTime DateAndTime { get; set; }
    public Guid CarId { get; set; }
    public Guid CustomerId { get; set; }

    public virtual Car Car { get; set; }
    public virtual Customer Customer { get; set; }
}
