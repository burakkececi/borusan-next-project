using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AdvertImage : Entity<Guid>
{
    public Guid AdvertId { get; set; }
    public string ImageURL { get; set; }

    public virtual Advert Advert { get; set; }
}
