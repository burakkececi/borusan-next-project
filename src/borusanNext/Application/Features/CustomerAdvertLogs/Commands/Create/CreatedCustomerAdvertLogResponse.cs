using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.CustomerAdvertLogs.Commands.Create;

public class CreatedCustomerAdvertLogResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid AdvertId { get; set; }
    public CustomerContactInformation ContactStatus { get; set; }
}