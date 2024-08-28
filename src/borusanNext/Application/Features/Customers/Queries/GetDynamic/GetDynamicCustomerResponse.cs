using Domain.Entities;
using Domain.Enums;
using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetDynamic;
public class GetDynamicCustomerResponse:IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string IdentityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public bool IsPhoneVerified { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public CustomerType CustomerType { get; set; }
    public Guid AddressId { get; set; }
    public string AddressLine { get; set; }
}
