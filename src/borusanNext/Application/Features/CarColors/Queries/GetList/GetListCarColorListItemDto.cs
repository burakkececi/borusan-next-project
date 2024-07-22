using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CarColors.Queries.GetList;

public class GetListCarColorListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}