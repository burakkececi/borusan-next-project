using NArchitecture.Core.Application.Responses;

namespace Application.Features.AdvertImages.Commands.Create;

public class CreatedAdvertImageResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid AdvertId { get; set; }
    public string ImageURL { get; set; }
}