using NArchitecture.Core.Application.Responses;

namespace Application.Features.Adverts.Queries.GetById;

public class GetByIdAdvertResponse : IResponse
{
    public Guid Id { get; set; }
    public int AdvertNo { get; set; }
    public Guid CarId { get; set; }
}