using NArchitecture.Core.Application.Responses;

namespace Application.Features.CarModels.Commands.Update;

public class UpdatedCarModelResponse : IResponse
{
    public Guid Id { get; set; }
    public string ModelName { get; set; }
    public Guid BrandId { get; set; }
}