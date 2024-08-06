using NArchitecture.Core.Application.Responses;

namespace Application.Features.Licences.Queries.GetById;

public class GetByIdLicenceResponse : IResponse
{
    public Guid Id { get; set; }
    public int LicenceNo { get; set; }
    public string ProvidedBy { get; set; }
}