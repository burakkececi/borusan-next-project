using NArchitecture.Core.Application.Responses;

namespace Application.Features.Locations.Commands.Update;

public class UpdatedLocationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public decimal Latitute { get; set; }
    public decimal Longitute { get; set; }
}