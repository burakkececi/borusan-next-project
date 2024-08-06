using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Engine : Entity<Guid>
{
    public string EngineNo { get; set; }
    public int EngineCapacity { get; set; }
    public int MotorPower { get; set; }
    public int MaximumTorque { get; set; }
    public double Acceleration { get; set; }
    public int MaximumSpeed { get; set; }
    public int FuelTankVolume { get; set; }
    public double OutOfTownConsumptionRate { get; set; }
    public double UrbanConsumptionRate { get; set; }
    public double AverageConsumptionRate { get; set; }

    public Guid FuelTypeId { get; set; }

    public virtual FuelType FuelType { get; set; }
    public virtual ICollection<Car> Cars { get; set; }
}