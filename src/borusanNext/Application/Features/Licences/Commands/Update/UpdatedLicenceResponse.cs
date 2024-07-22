using NArchitecture.Core.Application.Responses;

namespace Application.Features.Licences.Commands.Update;

public class UpdatedLicenceResponse : IResponse
{
    public Guid Id { get; set; }
    public int LicenceNo { get; set; }
    public string LicenceOwner { get; set; }
}