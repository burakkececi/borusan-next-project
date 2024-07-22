using NArchitecture.Core.Application.Responses;

namespace Application.Features.FuelTypes.Queries.GetById;

public class GetByIdFuelTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}