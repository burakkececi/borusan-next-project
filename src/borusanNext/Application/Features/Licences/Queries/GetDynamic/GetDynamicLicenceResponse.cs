using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Licences.Queries.GetDynamic;
public class GetDynamicLicenceResponse:IResponse 
{
    public Guid Id { get; set; }
    public int LicenceNo { get; set; }
    public string LicenceOwner { get; set; }
}
