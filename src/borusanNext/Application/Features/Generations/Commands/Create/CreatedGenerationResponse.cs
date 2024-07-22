using NArchitecture.Core.Application.Responses;

namespace Application.Features.Generations.Commands.Create;

public class CreatedGenerationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}