using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Sellers.Queries.GetList;

public class GetListSellerListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public Guid LicenceId { get; set; }
    public Guid LocationId { get; set; }
}