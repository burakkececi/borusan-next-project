using NArchitecture.Core.Application.Responses;

namespace Application.Features.CarModels.Commands.Create;

public class CreatedCarModelResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string ModelName { get; set; }
    public double Lenght { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double FuelTank { get; set; }
    public double LuggageCapacity { get; set; }
    public double EmptyWeight { get; set; }
    public int ModelYear { get; set; }
    public Guid CarId { get; set; }
    public Guid ModalExtensionId { get; set; }
}