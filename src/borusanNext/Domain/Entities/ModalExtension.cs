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

    public Guid CarModelId { get; set; }
    public virtual CarModel CarModel { get; set; }

    public Guid GenerationId { get; set; }
    public virtual Generation Generation { get; set; }
    

}
