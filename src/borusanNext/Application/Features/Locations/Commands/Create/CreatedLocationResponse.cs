using NArchitecture.Core.Application.Responses;

namespace Application.Features.Locations.Commands.Create;

public class CreatedLocationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public decimal Latitute { get; set; }
    public decimal Longitute { get; set; }
}