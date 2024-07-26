using NArchitecture.Core.Application.Responses;

namespace Application.Features.GenerationImages.Commands.Create;

public class CreatedGenerationImageResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid GenerationId { get; set; }
    public string ImageURL { get; set; }
}