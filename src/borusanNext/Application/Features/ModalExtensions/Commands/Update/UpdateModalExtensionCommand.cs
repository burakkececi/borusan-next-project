using Application.Features.ModalExtensions.Constants;
using Application.Features.ModalExtensions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ModalExtensions.Constants.ModalExtensionsOperationClaims;

namespace Application.Features.ModalExtensions.Commands.Update;

public class UpdateModalExtensionCommand : IRequest<UpdatedModalExtensionResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required double Lenght { get; set; }
    public required double Width { get; set; }
    public required double Height { get; set; }
    public required double FuelTank { get; set; }
    public required double LuggageCapacity { get; set; }
    public required double EmptyWeight { get; set; }
    public required int ModelYear { get; set; }
    public required Guid CarModelId { get; set; }
    public required Guid GenerationId { get; set; }

    public string[] Roles => [Admin, Write, ModalExtensionsOperationClaims.Update];

    public class UpdateModalExtensionCommandHandler : IRequestHandler<UpdateModalExtensionCommand, UpdatedModalExtensionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModalExtensionRepository _modalExtensionRepository;
        private readonly ModalExtensionBusinessRules _modalExtensionBusinessRules;

        public UpdateModalExtensionCommandHandler(IMapper mapper, IModalExtensionRepository modalExtensionRepository,
                                         ModalExtensionBusinessRules modalExtensionBusinessRules)
        {
            _mapper = mapper;
            _modalExtensionRepository = modalExtensionRepository;
            _modalExtensionBusinessRules = modalExtensionBusinessRules;
        }

        public async Task<UpdatedModalExtensionResponse> Handle(UpdateModalExtensionCommand request, CancellationToken cancellationToken)
        {
            ModalExtension? modalExtension = await _modalExtensionRepository.GetAsync(predicate: me => me.Id == request.Id, cancellationToken: cancellationToken);
            await _modalExtensionBusinessRules.ModalExtensionShouldExistWhenSelected(modalExtension);
            modalExtension = _mapper.Map(request, modalExtension);

            await _modalExtensionRepository.UpdateAsync(modalExtension!);

            UpdatedModalExtensionResponse response = _mapper.Map<UpdatedModalExtensionResponse>(modalExtension);
            return response;
        }
    }
}