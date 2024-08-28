using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sellers.Commands.Update;

public class UpdatedSellerResponse : IResponse
{
    public required Guid UserId { get; set; }
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    public required Guid AddressId { get; set; }
    public required string AddressLine { get; set; }
    public required string Latitute { get; set; }
    public required string Longitute { get; set; }
    public required int LicenceNo { get; set; }
    public required string ProvidedBy { get; set; }
}