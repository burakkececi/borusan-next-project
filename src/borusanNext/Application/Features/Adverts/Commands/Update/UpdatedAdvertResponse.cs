using NArchitecture.Core.Application.Responses;

namespace Application.Features.Adverts.Commands.Update;

public class UpdatedAdvertResponse : IResponse
{
    public Guid Id { get; set; }
    public int AdvertNo { get; set; }
    public DateTime PublishedDate { get; set; }
    public Guid CarId { get; set; }
}