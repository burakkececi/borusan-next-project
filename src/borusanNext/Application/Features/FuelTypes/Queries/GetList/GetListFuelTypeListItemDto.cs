using NArchitecture.Core.Application.Dtos;

namespace Application.Features.FuelTypes.Queries.GetList;

public class GetListFuelTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}