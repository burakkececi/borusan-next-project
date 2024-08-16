using NArchitecture.Core.Application.Responses;
using Domain.Enums;
using Domain.Entities;

namespace Application.Features.CustomerAdvertLogs.Queries.GetById;

public class GetByIdCustomerAdvertLogResponse : IResponse
{
    public Guid Id { get; set; }
    public Customer Customer { get; set; }
    public Advert Advert { get; set; }
    public CustomerContactInformation ContactStatus { get; set; }
}