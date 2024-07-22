using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ExpertizeResult : Entity<Guid>
{
    public int CarDamageInformationRecord { get; set; }
    public DateTime InquiryDate { get; set; }
    public Guid ChassisPartId { get; set; }
    public Guid BodyShellPartId { get; set; }

    public virtual ChassisPart ChassisPart { get; set; }
    public virtual BodyShellPart BodyShellPart { get; set; }
    public virtual Car Car { get; set; }
}
