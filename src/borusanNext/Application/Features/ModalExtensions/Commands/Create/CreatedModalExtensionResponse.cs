using NArchitecture.Core.Application.Responses;

namespace Application.Features.ModalExtensions.Commands.Create;

public class CreatedModalExtensionResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CarModelId { get; set; }
    public Guid GenerationId { get; set; }
}