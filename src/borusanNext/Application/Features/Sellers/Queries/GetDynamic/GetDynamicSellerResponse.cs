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
    public string City { get; set; }
    public string District { get; set; }
    public string AddressLine { get; set; }
    public string Latitute { get; set; }
    public string Longitute { get; set; }
    public int LicenceNo { get; set; }
    public string ProvidedBy { get; set; }
}
