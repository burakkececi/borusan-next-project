using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ModalExtension : Entity<Guid>
{
    public string Name { get; set; }
    public double Lenght { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double FuelTank { get; set; }
    public double LuggageCapacity { get; set; }
    public double EmptyWeight { get; set; }
    public int ModelYear { get; set; }
    public Guid CarModelId { get; set; }
    public Guid GenerationId { get; set; }
    public Guid EngineId { get; set; }
    public Guid BodyTypeId { get; set; }
    public Guid TransmissionId { get; set; }

    public virtual CarModel CarModel { get; set; }
    public virtual Generation Generation { get; set; }
    public virtual Car Car { get; set; }
    public virtual Engine Engine { get; set; }
    public virtual BodyType BodyType { get; set; }
    public virtual Transmission Transmission { get; set; }

}
