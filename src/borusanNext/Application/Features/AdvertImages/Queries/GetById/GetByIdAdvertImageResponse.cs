using NArchitecture.Core.Application.Responses;

namespace Application.Features.AdvertImages.Queries.GetById;

public class GetByIdAdvertImageResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid AdvertId { get; set; }
    public string ImageURL { get; set; }
}