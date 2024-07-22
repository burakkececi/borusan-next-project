using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using NArchitecture.Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Customer : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public bool IsSmsConfirmed { get; set; }
    public CustomerType CustomerType { get; set; }

    public virtual User User { get; set; }
    public ICollection<CustomerAdvertLog> CustomerAdvertLogs { get; set; }   
    public ICollection<Appointment> Appointments { get; set; }

}
