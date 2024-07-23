using NArchitecture.Core.Application.Responses;

namespace Application.Features.FuelTypes.Commands.Delete;

public class DeletedFuelTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}