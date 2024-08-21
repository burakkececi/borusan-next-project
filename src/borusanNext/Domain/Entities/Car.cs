using NArchitecture.Core.Persistence.Repositories;

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

    public Guid ModalExtensionId { get; set; }
    public Guid ColorId { get; set; }
    public Guid TramerId { get; set; }
    public Guid SellerId { get; set; }

    public virtual ModalExtension ModalExtension { get; set; }
    public virtual CarColor Color { get; set; }
    public virtual ExpertizeResult ExpertizeResult { get; set; }
    public virtual Advert Advert { get; set; }
    public virtual Seller Seller { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; }

}
