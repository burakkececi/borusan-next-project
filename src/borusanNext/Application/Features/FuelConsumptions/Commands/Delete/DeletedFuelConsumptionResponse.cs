using NArchitecture.Core.Application.Responses;

namespace Application.Features.FuelConsumptions.Commands.Delete;

public class DeletedFuelConsumptionResponse : IResponse
{
    public Guid Id { get; set; }
}