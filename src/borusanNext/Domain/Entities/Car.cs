using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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
    public int CarModelId { get; set; }
    public virtual CarModel CarModel { get; set; }

    public Guid ColorId { get; set; }
    public virtual CarColor Color { get; set; }

    public Guid EngineId { get; set; }
    public virtual Engine Engine { get; set; }

    public Guid BodyTypeId { get; set; }
    public virtual BodyType BodyType { get; set; }

    public Guid TransmissionId { get; set; }
    public virtual Transmission Transmission { get;set; }

    public Guid TramerId { get; set; }
    
    public virtual ExpertizeResult ExpertizeResult { get; set; } 

    public  Guid AdvertId { get; set; }

    public virtual Advert Advert { get; set; }
    
}
