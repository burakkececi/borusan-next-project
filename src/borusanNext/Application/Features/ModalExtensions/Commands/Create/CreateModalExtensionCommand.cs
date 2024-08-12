using Application.Features.ModalExtensions.Constants;
using Application.Features.ModalExtensions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ModalExtensions.Constants.ModalExtensionsOperationClaims;

namespace Application.Features.ModalExtensions.Commands.Create;

public class CreateModalExtensionCommand : IRequest<CreatedModalExtensionResponse>, ISecuredRequest
{
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

    public string[] Roles => [Admin, Write, ModalExtensionsOperationClaims.Create];

    public class CreateModalExtensionCommandHandler : IRequestHandler<CreateModalExtensionCommand, CreatedModalExtensionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModalExtensionRepository _modalExtensionRepository;
        private readonly ModalExtensionBusinessRules _modalExtensionBusinessRules;

        public CreateModalExtensionCommandHandler(IMapper mapper, IModalExtensionRepository modalExtensionRepository,
                                         ModalExtensionBusinessRules modalExtensionBusinessRules)
        {
            _mapper = mapper;
            _modalExtensionRepository = modalExtensionRepository;
            _modalExtensionBusinessRules = modalExtensionBusinessRules;
        }

        public async Task<CreatedModalExtensionResponse> Handle(CreateModalExtensionCommand request, CancellationToken cancellationToken)
        {
            ModalExtension modalExtension = _mapper.Map<ModalExtension>(request);
            await _modalExtensionBusinessRules.CarModelIdShouldExistWhenBindingToModalExtensions(modalExtension.CarModelId, cancellationToken);
            await _modalExtensionBusinessRules.GenerationIdShouldExistWhenBindingToModalExtensions(modalExtension.GenerationId, cancellationToken);
            await _modalExtensionRepository.AddAsync(modalExtension);

            CreatedModalExtensionResponse response = _mapper.Map<CreatedModalExtensionResponse>(modalExtension);
            return response;
        }
    }
}