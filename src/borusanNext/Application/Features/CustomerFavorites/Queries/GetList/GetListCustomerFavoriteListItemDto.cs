using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CustomerFavorites.Queries.GetList;

public class GetListCustomerFavoriteListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid AdvertId { get; set; }
}