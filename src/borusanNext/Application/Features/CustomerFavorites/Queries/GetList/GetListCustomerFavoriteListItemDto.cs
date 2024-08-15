using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CustomerFavorites.Queries.GetList;

public class GetListCustomerFavoriteListItemDto : IDto
{
    public Guid Id { get; set; }
    public Customer Customer { get; set; }
    public Advert Advert { get; set; }
}