using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CarModel : Entity<Guid>
{
    public Guid BrandId { get; set; }
    public virtual Brand Brand { get; set; }

    public string ModelName { get; set; }
    public string ModalExtension { get; set; } // 1.2 X5 Premium
    public string Generation { get; set; }

    public Guid BodyTypeId { get; set; } // hatchback / 5
    public virtual BodyType BodyType { get; set; }

    public Guid TransmissionId { get; set; }
    public virtual Transmission Transmission { get; set; }
}

