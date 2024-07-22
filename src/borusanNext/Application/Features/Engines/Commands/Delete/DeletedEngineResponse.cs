using NArchitecture.Core.Application.Responses;

namespace Application.Features.Engines.Commands.Delete;

public class DeletedEngineResponse : IResponse
{
    public Guid Id { get; set; }
}