using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Customers.Commands.Delete;

public class DeletedCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public bool IsSmsConfirmed { get; set; }
    public CustomerType CustomerType { get; set; }
}