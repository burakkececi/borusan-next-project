using NArchitecture.Core.Application.Responses;

namespace Application.Features.Brands.Commands.Delete;

public class DeletedBrandResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
}