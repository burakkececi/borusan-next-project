using NArchitecture.Core.Application.Dtos;

namespace Application.Features.GenerationImages.Queries.GetList;

public class GetListGenerationImageListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid GenerationId { get; set; }
    public string ImageURL { get; set; }
}