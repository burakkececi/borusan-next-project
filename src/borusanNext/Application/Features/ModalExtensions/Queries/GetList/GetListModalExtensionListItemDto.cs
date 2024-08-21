using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ModalExtensions.Queries.GetList;

public class GetListModalExtensionListItemDto : IDto
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
    public Guid BrandId { get; set; }
    public Guid GenerationId { get; set; }
    public Guid EngineId { get; set; }
    public Guid BodyTypeId { get; set; }
    public Guid TransmissionId { get; set; }
}