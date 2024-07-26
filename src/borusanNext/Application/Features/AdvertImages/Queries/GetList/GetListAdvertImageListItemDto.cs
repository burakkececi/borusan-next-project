using NArchitecture.Core.Application.Dtos;

namespace Application.Features.AdvertImages.Queries.GetList;

public class GetListAdvertImageListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid AdvertId { get; set; }
    public string ImageURL { get; set; }
}