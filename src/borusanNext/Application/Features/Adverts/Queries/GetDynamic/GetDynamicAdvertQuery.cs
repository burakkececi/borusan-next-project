using Application.Features.Adverts.Queries.GetDynamic;
using Application.Features.Adverts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using static Application.Features.Adverts.Constants.AdvertsOperationClaims;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Brands.Queries.GetDynamic;

public class GetDynamicAdvertQuery : IRequest<GetListResponse<GetDynamicAdvertResponse>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetDynamicAdvertQueryHandler : IRequestHandler<GetDynamicAdvertQuery, GetListResponse<GetDynamicAdvertResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AdvertBusinessRules _advertBusinessRules;
        private readonly IAdvertRepository _advertRepository;

        public GetDynamicAdvertQueryHandler(IAdvertRepository advertRepository, IMapper mapper)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetDynamicAdvertResponse>> Handle(GetDynamicAdvertQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Advert> advert = await _advertRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);


            GetListResponse<GetDynamicAdvertResponse> response = _mapper.Map<GetListResponse<GetDynamicAdvertResponse>>(advert);
            return response;
        }
    }
}
