using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Locations.Queries.GetDynamic;
public class GetDynamicLocaitonResponse:IResponse
{
    public Guid Id { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Latitute { get; set; }
    public string Longitute { get; set; }
}
