using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models;
public sealed class AdvertDetailsReadModel
{
    public string AdvertNo { get; set; }
    public AdvertImage[] AdvertImages { get; set; }
    
    public Guid CarId { get; set; }
    public string ChassisNumber { get; set; }
    public string Plate { get; set; }
    public int Kilometers { get; set; }
    public bool SpareKey { get; set; }
    public DateTime Inquiry { get; set; }
    public string WheelType { get; set; }
    public bool SpareWheel { get; set; }
    public decimal Price { get; set; }

    public Guid CarModelId { get; set; }
    public Guid ColorId { get; set; }
    public Guid EngineId { get; set; }
    public Guid BodyTypeId { get; set; }
    public Guid TransmissionId { get; set; }
    public Guid TramerId { get; set; }
    public Guid SellerId { get; set; }

    public CarModel CarModel { get; set; }
    public CarColor Color { get; set; }
    public Engine Engine { get; set; }
    public BodyType BodyType { get; set; }
    public Transmission Transmission { get; set; }
    public ExpertizeResult ExpertizeResult { get; set; }
    public Advert Advert { get; set; }
    public Seller Seller { get; set; }
    public ICollection<Appointment> Appointments { get; set; }

}
