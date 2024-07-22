using NArchitecture.Core.Application.Responses;

namespace Application.Features.ModalExtensions.Commands.Delete;

public class DeletedModalExtensionResponse : IResponse
{
    public Guid Id { get; set; }
}