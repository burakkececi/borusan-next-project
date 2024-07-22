using NArchitecture.Core.Application.Responses;

namespace Application.Features.FuelConsumptions.Commands.Update;

public class UpdatedFuelConsumptionResponse : IResponse
{
    public Guid Id { get; set; }
    public double OutOfTown { get; set; }
    public double Urban { get; set; }
    public double Average { get; set; }
}