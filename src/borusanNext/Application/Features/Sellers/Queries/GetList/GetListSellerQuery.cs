using Application.Features.Sellers.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Sellers.Constants.SellersOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Sellers.Queries.GetList;

public class GetListSellerQuery : IRequest<GetListResponse<GetListSellerListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListSellerQueryHandler : IRequestHandler<GetListSellerQuery, GetListResponse<GetListSellerListItemDto>>
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;

        public GetListSellerQueryHandler(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSellerListItemDto>> Handle(GetListSellerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Seller> sellers = await _sellerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                include: i => i.Include(s => s.Location).Include(s => s.Licence),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSellerListItemDto> response = _mapper.Map<GetListResponse<GetListSellerListItemDto>>(sellers);
            return response;
        }
    }
}