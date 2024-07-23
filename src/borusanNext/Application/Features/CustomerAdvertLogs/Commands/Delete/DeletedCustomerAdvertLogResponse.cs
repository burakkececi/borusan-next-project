using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.CustomerAdvertLogs.Commands.Delete;

public class DeletedCustomerAdvertLogResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid AdvertId { get; set; }
    public CustomerContactInformation ContactStatus { get; set; }
}