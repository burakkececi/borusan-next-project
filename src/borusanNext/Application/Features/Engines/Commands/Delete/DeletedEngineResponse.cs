using NArchitecture.Core.Application.Responses;

namespace Application.Features.Engines.Commands.Delete;

public class DeletedEngineResponse : IResponse
{
    public Guid Id { get; set; }
    public string EngineNo { get; set; }
    public int EngineCapacity { get; set; }
    public int MotorPower { get; set; }
    public int MaximumTorque { get; set; }
    public double Acceleration { get; set; }
    public int MaximumSpeed { get; set; }
    public int FuelTankVolume { get; set; }
    public Guid FuelTypeId { get; set; }
    public Guid FuelConsumptionId { get; set; }
}