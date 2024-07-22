using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.CustomerAdvertLogs.Commands.Update;

public class UpdatedCustomerAdvertLogResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid AdvertId { get; set; }
    public CustomerContactInformation ContactStatus { get; set; }
}