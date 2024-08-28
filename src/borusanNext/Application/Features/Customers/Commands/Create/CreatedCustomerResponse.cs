using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Customers.Commands.Create;

public class CreatedCustomerResponse : IResponse
{
    public required Guid Id { get; set; }
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