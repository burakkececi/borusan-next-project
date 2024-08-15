using NArchitecture.Core.Application.Responses;
using Domain.Enums;
using Domain.Entities;

namespace Application.Features.Customers.Queries.GetById;

public class GetByIdCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public Customer Customer { get; set; }
    public CustomerAdvertLog CustomerAdvertLog { get; set; }
    public CustomerType CustomerType { get; set; }
}