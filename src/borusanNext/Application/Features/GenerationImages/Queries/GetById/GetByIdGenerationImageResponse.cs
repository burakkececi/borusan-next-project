using NArchitecture.Core.Application.Responses;

namespace Application.Features.GenerationImages.Queries.GetById;

public class GetByIdGenerationImageResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid GenerationId { get; set; }
    public string ImageURL { get; set; }
}