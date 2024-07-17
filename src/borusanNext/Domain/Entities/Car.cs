using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Car : Entity<Guid>
{
    public string ChassisNumber { get; set; }
    public string Plate { get; set; }
    public int Kilometers { get; set; }
    public bool SpareKey { get; set; }
    public DateTime Inquiry { get; set; }
    public string WheelType { get; set; }
    public bool SpareWheel { get; set; }
    public decimal Price { get; set; }

    public Guid CarDimensionId { get; set; }
    public virtual CarDimension CarDimension { get; set; }

    public int CarModelId { get; set; }
    public virtual CarModel CarModel { get; set; }

    public Guid ColorId { get; set; }
    public virtual CarColor Color { get; set; }

    public Guid EngineId { get; set; }
    public virtual Engine Engine { get; set; }
}
