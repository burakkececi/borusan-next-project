using NArchitecture.Core.Application.Responses;

namespace Application.Features.GenerationImages.Commands.Delete;

public class DeletedGenerationImageResponse : IResponse
{
    public Guid Id { get; set; }
}