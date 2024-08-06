using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Engines.Queries.GetList;

public class GetListEngineListItemDto : IDto
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
    public double OutOfTownConsumptionRate { get; set; }
    public double UrbanConsumptionRate { get; set; }
    public double AverageConsumptionRate { get; set; }
}