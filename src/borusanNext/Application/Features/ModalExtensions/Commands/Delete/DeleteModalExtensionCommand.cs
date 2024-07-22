using Application.Features.ModalExtensions.Constants;
using Application.Features.ModalExtensions.Constants;
using Application.Features.ModalExtensions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ModalExtensions.Constants.ModalExtensionsOperationClaims;

namespace Application.Features.ModalExtensions.Commands.Delete;

public class DeleteModalExtensionCommand : IRequest<DeletedModalExtensionResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ModalExtensionsOperationClaims.Delete];

    public class DeleteModalExtensionCommandHandler : IRequestHandler<DeleteModalExtensionCommand, DeletedModalExtensionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModalExtensionRepository _modalExtensionRepository;
        private readonly ModalExtensionBusinessRules _modalExtensionBusinessRules;

        public DeleteModalExtensionCommandHandler(IMapper mapper, IModalExtensionRepository modalExtensionRepository,
                                         ModalExtensionBusinessRules modalExtensionBusinessRules)
        {
            _mapper = mapper;
            _modalExtensionRepository = modalExtensionRepository;
            _modalExtensionBusinessRules = modalExtensionBusinessRules;
        }

        public async Task<DeletedModalExtensionResponse> Handle(DeleteModalExtensionCommand request, CancellationToken cancellationToken)
        {
            ModalExtension? modalExtension = await _modalExtensionRepository.GetAsync(predicate: me => me.Id == request.Id, cancellationToken: cancellationToken);
            await _modalExtensionBusinessRules.ModalExtensionShouldExistWhenSelected(modalExtension);

            await _modalExtensionRepository.DeleteAsync(modalExtension!);

            DeletedModalExtensionResponse response = _mapper.Map<DeletedModalExtensionResponse>(modalExtension);
            return response;
        }
    }
}