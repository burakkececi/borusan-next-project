using NArchitecture.Core.Application.Responses;

namespace Application.Features.CarColors.Queries.GetById;

public class GetByIdCarColorResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}