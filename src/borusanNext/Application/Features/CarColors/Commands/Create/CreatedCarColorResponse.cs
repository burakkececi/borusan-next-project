using NArchitecture.Core.Application.Responses;

namespace Application.Features.CarColors.Commands.Create;

public class CreatedCarColorResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}