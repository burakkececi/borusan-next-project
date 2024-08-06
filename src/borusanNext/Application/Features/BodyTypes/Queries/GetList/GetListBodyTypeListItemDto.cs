using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BodyTypes.Queries.GetList;

public class GetListBodyTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string BodyName { get; set; }
    public string Door { get; set; }
}