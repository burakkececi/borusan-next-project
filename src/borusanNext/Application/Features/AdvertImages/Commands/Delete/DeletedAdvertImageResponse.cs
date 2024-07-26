using NArchitecture.Core.Application.Responses;

namespace Application.Features.AdvertImages.Commands.Delete;

public class DeletedAdvertImageResponse : IResponse
{
    public Guid Id { get; set; }
}