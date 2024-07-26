using NArchitecture.Core.Application.Responses;

namespace Application.Features.ModalExtensions.Commands.Create;

public class CreatedModalExtensionResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Lenght { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double FuelTank { get; set; }
    public double LuggageCapacity { get; set; }
    public double EmptyWeight { get; set; }
    public int ModelYear { get; set; }
    public Guid CarModelId { get; set; }
    public Guid GenerationId { get; set; }
}