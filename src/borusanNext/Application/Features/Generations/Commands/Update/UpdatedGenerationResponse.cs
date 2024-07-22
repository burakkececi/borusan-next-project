using NArchitecture.Core.Application.Responses;

namespace Application.Features.Generations.Commands.Update;

public class UpdatedGenerationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}