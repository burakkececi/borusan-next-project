using Application.Features.BodyTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.BodyTypes.Constants.BodyTypesOperationClaims;

namespace Application.Features.BodyTypes.Queries.GetList;

public class GetListBodyTypeQuery : IRequest<GetListResponse<GetListBodyTypeListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListBodyTypeQueryHandler : IRequestHandler<GetListBodyTypeQuery, GetListResponse<GetListBodyTypeListItemDto>>
    {
        private readonly IBodyTypeRepository _bodyTypeRepository;
        private readonly IMapper _mapper;

        public GetListBodyTypeQueryHandler(IBodyTypeRepository bodyTypeRepository, IMapper mapper)
        {
            _bodyTypeRepository = bodyTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBodyTypeListItemDto>> Handle(GetListBodyTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BodyType> bodyTypes = await _bodyTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBodyTypeListItemDto> response = _mapper.Map<GetListResponse<GetListBodyTypeListItemDto>>(bodyTypes);
            return response;
        }
    }
}