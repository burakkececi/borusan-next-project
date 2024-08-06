using NArchitecture.Core.Application.Responses;

namespace Application.Features.Locations.Commands.Create;

public class CreatedLocationResponse : IResponse
{
    public Guid Id { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Latitute { get; set; }
    public string Longitute { get; set; }
}