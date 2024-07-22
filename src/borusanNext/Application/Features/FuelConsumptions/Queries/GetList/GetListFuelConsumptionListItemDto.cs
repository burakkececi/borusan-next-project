using NArchitecture.Core.Application.Dtos;

namespace Application.Features.FuelConsumptions.Queries.GetList;

public class GetListFuelConsumptionListItemDto : IDto
{
    public Guid Id { get; set; }
    public double OutOfTown { get; set; }
    public double Urban { get; set; }
    public double Average { get; set; }
}