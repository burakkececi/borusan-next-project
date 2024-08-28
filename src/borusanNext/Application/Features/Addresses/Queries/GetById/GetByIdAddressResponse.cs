using NArchitecture.Core.Application.Responses;

namespace Application.Features.Addresses.Queries.GetById;

public class GetByIdAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public string City { get; set; }
    public string District { get; set; }
}