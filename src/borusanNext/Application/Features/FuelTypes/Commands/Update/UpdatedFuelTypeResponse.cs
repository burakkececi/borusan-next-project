using NArchitecture.Core.Application.Responses;

namespace Application.Features.FuelTypes.Commands.Update;

public class UpdatedFuelTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}