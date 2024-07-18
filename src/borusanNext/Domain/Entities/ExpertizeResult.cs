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
    public List<ChassisPart> ChassisParts { get; set; }
    public List<BodyShellPart> BodyParts { get; set; }
}
