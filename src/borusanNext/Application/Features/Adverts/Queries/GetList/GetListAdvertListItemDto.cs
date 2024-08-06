using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Adverts.Queries.GetList;

public class GetListAdvertListItemDto : IDto
{
    public Guid Id { get; set; }
    public int AdvertNo { get; set; }
    public Guid CarId { get; set; }
}