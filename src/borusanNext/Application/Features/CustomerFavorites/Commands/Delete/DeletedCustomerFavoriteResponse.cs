using NArchitecture.Core.Application.Responses;

namespace Application.Features.CustomerFavorites.Commands.Delete;

public class DeletedCustomerFavoriteResponse : IResponse
{
    public Guid Id { get; set; }
}