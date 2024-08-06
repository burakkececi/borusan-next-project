using NArchitecture.Core.Application.Responses;

namespace Application.Features.BodyTypes.Commands.Create;

public class CreatedBodyTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string BodyName { get; set; }
    public string Door { get; set; }
}