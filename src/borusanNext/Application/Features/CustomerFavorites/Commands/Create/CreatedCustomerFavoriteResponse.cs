using NArchitecture.Core.Application.Responses;

namespace Application.Features.CustomerFavorites.Commands.Create;

public class CreatedCustomerFavoriteResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid AdvertId { get; set; }
}