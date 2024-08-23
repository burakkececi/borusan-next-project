using Application.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Application.Features.AdvertDetails.Constants;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Persistence.Dynamic;

namespace Application.Features.AdvertDetails.Queries.GetDynamic;
public class GetDynamicAdvertDetailsQuery : IRequest<GetListResponse<AdvertDetailsReadModel>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [AdvertDetailsOperationClaims.Admin, AdvertDetailsOperationClaims.Read];

    public class GetDynamicAdvertDetailsQueryHandler : IRequestHandler<GetDynamicAdvertDetailsQuery, GetListResponse<AdvertDetailsReadModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertDetailsReadRepository _advertDetailsReadRepository;

        public GetDynamicAdvertDetailsQueryHandler(IMapper mapper, IAdvertDetailsReadRepository advertDetailsReadRepository)
        {
            _mapper = mapper;
            _advertDetailsReadRepository = advertDetailsReadRepository;
        }

        public async Task<GetListResponse<AdvertDetailsReadModel>> Handle(GetDynamicAdvertDetailsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AdvertDetailsReadModel> advertDetails = await _advertDetailsReadRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );

            GetListResponse<AdvertDetailsReadModel> response = _mapper.Map<GetListResponse<AdvertDetailsReadModel>>(advertDetails);
            return response;
        }
    }
}
