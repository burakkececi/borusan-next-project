using Application.Features.ModalExtensions.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.ModalExtensions.Constants.ModalExtensionsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ModalExtensions.Queries.GetList;

public class GetListModalExtensionQuery : IRequest<GetListResponse<GetListModalExtensionListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListModalExtensionQueryHandler : IRequestHandler<GetListModalExtensionQuery, GetListResponse<GetListModalExtensionListItemDto>>
    {
        private readonly IModalExtensionRepository _modalExtensionRepository;
        private readonly IMapper _mapper;

        public GetListModalExtensionQueryHandler(IModalExtensionRepository modalExtensionRepository, IMapper mapper)
        {
            _modalExtensionRepository = modalExtensionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListModalExtensionListItemDto>> Handle(GetListModalExtensionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ModalExtension> modalExtensions = await _modalExtensionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: i => i.Include(m => m.Generation).Include(m => m.CarModel),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListModalExtensionListItemDto> response = _mapper.Map<GetListResponse<GetListModalExtensionListItemDto>>(modalExtensions);
            return response;
        }
    }
}