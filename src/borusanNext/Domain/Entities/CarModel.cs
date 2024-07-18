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
    public double Lenght { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double FuelTank { get; set; }
    public double LuggageCapacity { get; set; }
    public double EmptyWeight { get; set; }
    public int ModelYear { get; set; }

    public Guid CarId { get; set; }
    public virtual ICollection<Car> Cars { get; set; }

    public Guid ModalExtensionId { get; set; }
    public virtual ICollection<ModalExtension> ModalExtensions { get; set; }
}

