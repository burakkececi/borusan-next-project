using NArchitecture.Core.Application.Responses;

namespace Application.Features.Licences.Commands.Create;

public class CreatedLicenceResponse : IResponse
{
    public Guid Id { get; set; }
    public int LicenceNo { get; set; }
    public string LicenceOwner { get; set; }
}