using NArchitecture.Core.Application.Responses;

namespace Application.Features.Generations.Commands.Delete;

public class DeletedGenerationResponse : IResponse
{
    public Guid Id { get; set; }
}