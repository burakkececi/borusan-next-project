using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sellers.Queries.GetById;

public class GetByIdSellerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public Guid LicenceId { get; set; }
    public Guid LocationId { get; set; }
}