using NArchitecture.Core.Application.Responses;

namespace Application.Features.CarColors.Commands.Update;

public class UpdatedCarColorResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}