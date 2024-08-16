using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.CustomerFavorites.Queries.GetById;

public class GetByIdCustomerFavoriteResponse : IResponse
{
    public Guid Id { get; set; }
    public Customer Customer { get; set; }
    public Advert Advert { get; set; }
}