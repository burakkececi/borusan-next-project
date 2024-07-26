using NArchitecture.Core.Application.Responses;

namespace Application.Features.CustomerFavorites.Queries.GetById;

public class GetByIdCustomerFavoriteResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid AdvertId { get; set; }
}