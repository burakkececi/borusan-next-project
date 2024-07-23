using NArchitecture.Core.Application.Responses;

namespace Application.Features.Generations.Commands.Delete;

public class DeletedGenerationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}