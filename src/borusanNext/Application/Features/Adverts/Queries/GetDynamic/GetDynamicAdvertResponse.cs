using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adverts.Queries.GetDynamic;
public class GetDynamicAdvertResponse:IResponse
{
    public Guid Id { get; set; }
    public int AdvertNo { get; set; }
    public Guid CarId { get; set; }
}
