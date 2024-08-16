using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sellers.Queries.GetDynamic;
public class GetDynamicSellerResponse:IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public Licence Licence { get; set; }
    public Location Location { get; set; }
}
