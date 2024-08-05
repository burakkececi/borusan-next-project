using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ChassisParts.Queries.GetDynamic;
public class GetDynamicChassisPartsResponse:IResponse
{
    public Guid Id { get; set; }
    public bool IsRightChassisChanged { get; set; }
    public bool IsLeftChassisChanged { get; set; }
    public bool IsFrontPanelChanged { get; set; }
    public bool IsBackPanelChanged { get; set; }
}
