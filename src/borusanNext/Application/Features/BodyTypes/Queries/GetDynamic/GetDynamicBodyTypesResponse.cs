using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BodyTypes.Queries.GetDynamic;
public class GetDynamicBodyTypesResponse:IResponse
{
    public Guid Id { get; set; }
    public string BodyName { get; set; }
    public string Door { get; set; }
}
