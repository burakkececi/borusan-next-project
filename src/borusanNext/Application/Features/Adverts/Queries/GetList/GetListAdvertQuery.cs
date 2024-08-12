using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Adverts.Constants.AdvertsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Adverts.Queries.GetList;

public class GetListAdvertQuery : IRequest<GetListResponse<GetListAdvertListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListAdvertQueryHandler : IRequestHandler<GetListAdvertQuery, GetListResponse<GetListAdvertListItemDto>>
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public GetListAdvertQueryHandler(IAdvertRepository advertRepository, IMapper mapper)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAdvertListItemDto>> Handle(GetListAdvertQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Advert> adverts = await _advertRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: i => i.Include(p => p.Car).Include(p => p.AdvertImages),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAdvertListItemDto> response = _mapper.Map<GetListResponse<GetListAdvertListItemDto>>(adverts);
            return response;
        }
    }
}