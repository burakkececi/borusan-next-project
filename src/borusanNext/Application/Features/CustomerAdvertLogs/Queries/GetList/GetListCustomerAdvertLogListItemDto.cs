using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.CustomerAdvertLogs.Queries.GetList;

public class GetListCustomerAdvertLogListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid AdvertId { get; set; }
    public CustomerContactInformation ContactStatus { get; set; }
}