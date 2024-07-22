using NArchitecture.Core.Application.Responses;

namespace Application.Features.BodyTypes.Queries.GetById;

public class GetByIdBodyTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BodyName { get; set; }
    public string Door { get; set; }
}