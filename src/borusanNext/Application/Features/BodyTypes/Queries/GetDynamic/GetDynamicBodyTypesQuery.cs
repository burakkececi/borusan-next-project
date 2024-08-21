using Application.Features.BodyTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.BodyTypes.Constants.BodyTypesOperationClaims;

namespace Application.Features.BodyTypes.Queries.GetDynamic;
public class GetDynamicBodyTypesQuery : IRequest<GetListResponse<GetDynamicBodyTypesResponse>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetDynamicBodyTypesQueryHandler : IRequestHandler<GetDynamicBodyTypesQuery, GetListResponse<GetDynamicBodyTypesResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBodyTypeRepository _bodyTypeRepository;
        private readonly BodyTypeBusinessRules _bodyTypeBusinessRules;

        public GetDynamicBodyTypesQueryHandler(IMapper mapper, IBodyTypeRepository bodyTypeRepository, BodyTypeBusinessRules bodyTypeBusinessRules)
        {
            _mapper = mapper;
            _bodyTypeRepository = bodyTypeRepository;
            _bodyTypeBusinessRules = bodyTypeBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicBodyTypesResponse>> Handle(GetDynamicBodyTypesQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BodyType> bodyType = await _bodyTypeRepository.GetListByDynamicAsync(
              dynamic: request.DynamicQuery,
              index: request.PageRequest.PageIndex,
              size: request.PageRequest.PageSize,
              cancellationToken: cancellationToken);


            GetListResponse<GetDynamicBodyTypesResponse> response = _mapper.Map<GetListResponse<GetDynamicBodyTypesResponse>>(bodyType);
            return response;
        }
    }
}
