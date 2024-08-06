using NArchitecture.Core.Application.Responses;

namespace Application.Features.Engines.Commands.Create;

public class CreatedEngineResponse : IResponse
{
    public Guid Id { get; set; }
}