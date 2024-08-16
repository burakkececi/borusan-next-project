using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpertizeResults.Queries.GetDynamic;
public class GetDynamicExpertizeResponse:IResponse 
{
    public Guid Id { get; set; }
    public int CarDamageInformationRecord { get; set; }
    public DateTime InquiryDate { get; set; }
    public ChassisPart ChassisPart { get; set; }
    public BodyShellPart BodyShellPart { get; set; }
}
