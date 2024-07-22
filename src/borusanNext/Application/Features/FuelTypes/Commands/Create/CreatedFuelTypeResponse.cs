using NArchitecture.Core.Application.Responses;

namespace Application.Features.FuelTypes.Commands.Create;

public class CreatedFuelTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}