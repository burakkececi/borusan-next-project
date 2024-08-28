using Application.Features.ModalExtensions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.ModalExtensions.Constants.ModalExtensionsOperationClaims;


namespace Application.Features.ModalExtensions.Queries.GetDynamic;
public class GetDynamicModalExtensionsQuery : IRequest<GetListResponse<GetDynamicModalExtensionsResponse>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetDynamicModalExtensionsQueryHandler : IRequestHandler<GetDynamicModalExtensionsQuery, GetListResponse<GetDynamicModalExtensionsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IModalExtensionRepository _modalExtensionRepository;
        private readonly ModalExtensionBusinessRules _modalExtensionBusinessRules;

        public GetDynamicModalExtensionsQueryHandler(IMapper mapper, IModalExtensionRepository modalExtensionRepository, ModalExtensionBusinessRules modalExtensionBusinessRules)
        {
            _mapper = mapper;
            _modalExtensionRepository = modalExtensionRepository;
            _modalExtensionBusinessRules = modalExtensionBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicModalExtensionsResponse>> Handle(GetDynamicModalExtensionsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ModalExtension> modalExtension = await _modalExtensionRepository.GetListByDynamicAsync(
             dynamic: request.DynamicQuery,
             include: i => i.Include(m => m.Generation)
                         .Include(m => m.CarModel).ThenInclude(m => m.Brand)
                         .Include(m => m.Engine).ThenInclude(m => m.FuelType)
                         .Include(m => m.BodyType)
                         .Include(m => m.Transmission),
             index: request.PageRequest.PageIndex,
             size: request.PageRequest.PageSize,
             cancellationToken: cancellationToken);


            GetListResponse<GetDynamicModalExtensionsResponse> response = _mapper.Map<GetListResponse<GetDynamicModalExtensionsResponse>>(modalExtension);
            return response;
        }
    }
}
