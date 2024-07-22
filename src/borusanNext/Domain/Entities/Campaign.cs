using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Campaign : Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Banner { get; set; }  
}
