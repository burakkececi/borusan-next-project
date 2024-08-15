using NArchitecture.Core.Application.Dtos;
using Domain.Enums;
using Domain.Entities;

namespace Application.Features.CustomerAdvertLogs.Queries.GetList;

public class GetListCustomerAdvertLogListItemDto : IDto
{
    public Guid Id { get; set; }
    public Customer Customer { get; set; }
    public Advert Advert { get; set; }
    public CustomerContactInformation ContactStatus { get; set; }
}