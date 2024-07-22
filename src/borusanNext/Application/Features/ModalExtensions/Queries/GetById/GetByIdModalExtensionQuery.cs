using Application.Features.ModalExtensions.Constants;
using Application.Features.ModalExtensions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ModalExtensions.Constants.ModalExtensionsOperationClaims;

namespace Application.Features.ModalExtensions.Queries.GetById;

public class GetByIdModalExtensionQuery : IRequest<GetByIdModalExtensionResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdModalExtensionQueryHandler : IRequestHandler<GetByIdModalExtensionQuery, GetByIdModalExtensionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModalExtensionRepository _modalExtensionRepository;
        private readonly ModalExtensionBusinessRules _modalExtensionBusinessRules;

        public GetByIdModalExtensionQueryHandler(IMapper mapper, IModalExtensionRepository modalExtensionRepository, ModalExtensionBusinessRules modalExtensionBusinessRules)
        {
            _mapper = mapper;
            _modalExtensionRepository = modalExtensionRepository;
            _modalExtensionBusinessRules = modalExtensionBusinessRules;
        }

        public async Task<GetByIdModalExtensionResponse> Handle(GetByIdModalExtensionQuery request, CancellationToken cancellationToken)
        {
            ModalExtension? modalExtension = await _modalExtensionRepository.GetAsync(predicate: me => me.Id == request.Id, cancellationToken: cancellationToken);
            await _modalExtensionBusinessRules.ModalExtensionShouldExistWhenSelected(modalExtension);

            GetByIdModalExtensionResponse response = _mapper.Map<GetByIdModalExtensionResponse>(modalExtension);
            return response;
        }
    }
}