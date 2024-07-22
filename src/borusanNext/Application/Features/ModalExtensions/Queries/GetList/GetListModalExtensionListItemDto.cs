using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ModalExtensions.Queries.GetList;

public class GetListModalExtensionListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CarModelId { get; set; }
    public Guid GenerationId { get; set; }
}