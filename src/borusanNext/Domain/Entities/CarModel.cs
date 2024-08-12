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
    public string ModelName { get; set; }
    public Guid BrandId { get; set; }

    public virtual Brand Brand { get; set; }
    public virtual ICollection<ModalExtension> ModalExtensions { get; set; }
}

