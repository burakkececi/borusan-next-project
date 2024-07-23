using NArchitecture.Core.Application.Responses;

namespace Application.Features.Licences.Commands.Delete;

public class DeletedLicenceResponse : IResponse
{
    public Guid Id { get; set; }
    public int LicenceNo { get; set; }
    public string LicenceOwner { get; set; }
}