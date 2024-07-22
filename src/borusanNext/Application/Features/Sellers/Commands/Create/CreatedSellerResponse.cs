using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sellers.Commands.Create;

public class CreatedSellerResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public Guid LicenceId { get; set; }
    public Guid LocationId { get; set; }
}