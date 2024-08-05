using NArchitecture.Core.Application.Responses;

namespace Application.Features.Adverts.Commands.Create;

public class CreatedAdvertResponse : IResponse
{
    public Guid Id { get; set; }
    public int AdvertNo { get; set; }
    public Guid CarId { get; set; }
}