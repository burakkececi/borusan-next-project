using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Locations.Queries.GetList;

public class GetListLocationListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Latitute { get; set; }
    public string Longitute { get; set; }
}