using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CarDimension : Entity<Guid>
{
    public int Lenght { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int FuelTank { get; set; }
    public int LuggageCapacity { get; set; }
    public int EmptyWeight { get; set; }

    public virtual Car Car { get; set; }
}
