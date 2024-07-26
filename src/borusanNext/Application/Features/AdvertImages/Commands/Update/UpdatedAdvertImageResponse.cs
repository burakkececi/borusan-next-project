using NArchitecture.Core.Application.Responses;

namespace Application.Features.AdvertImages.Commands.Update;

public class UpdatedAdvertImageResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid AdvertId { get; set; }
    public string ImageURL { get; set; }
}