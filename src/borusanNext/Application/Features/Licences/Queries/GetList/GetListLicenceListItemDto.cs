using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Licences.Queries.GetList;

public class GetListLicenceListItemDto : IDto
{
    public Guid Id { get; set; }
    public int LicenceNo { get; set; }
    public string ProvidedBy { get; set; }
}