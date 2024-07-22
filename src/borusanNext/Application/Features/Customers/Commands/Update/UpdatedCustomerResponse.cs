using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Customers.Commands.Update;

public class UpdatedCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Phone { get; set; }
    public bool IsSmsConfirmed { get; set; }
    public CustomerType CustomerType { get; set; }
}