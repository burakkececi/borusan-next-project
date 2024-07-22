using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Customers.Commands.Create;

public class CreatedCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public bool IsSmsConfirmed { get; set; }
    public CustomerType CustomerType { get; set; }
}