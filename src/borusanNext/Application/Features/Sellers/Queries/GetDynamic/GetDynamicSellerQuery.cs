using Application.Features.ModalExtensions.Queries.GetDynamic;
using Application.Features.Sellers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Sellers.Constants.SellersOperationClaims;


namespace Application.Features.Sellers.Queries.GetDynamic;
public class GetDynamicSellerQuery : IRequest<GetListResponse<GetDynamicSellerResponse>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public bool BypassCache => false;

    public string CacheKey => $"GetDynamicListSellerQuery.PageIndex={PageRequest.PageIndex}&PageSize={PageRequest.PageSize}";

    public string? CacheGroupKey => "Seller.Get";

    public TimeSpan? SlidingExpiration { get; }

    public string[] Roles => [Admin, Read];

    public class GetDynamicSellerQueryHandler : IRequestHandler<GetDynamicSellerQuery, GetListResponse<GetDynamicSellerResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ISellerRepository _sellerRepository;
        private readonly SellerBusinessRules _sellerBusinessRules;

        public GetDynamicSellerQueryHandler(IMapper mapper, ISellerRepository sellerRepository, SellerBusinessRules sellerBusinessRules)
        {
            _mapper = mapper;
            _sellerRepository = sellerRepository;
            _sellerBusinessRules = sellerBusinessRules;
        }

        public async Task<GetListResponse<GetDynamicSellerResponse>> Handle(GetDynamicSellerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Seller> seller = await _sellerRepository.GetListByDynamicAsync(
             dynamic: request.DynamicQuery,
             include: i => i.Include(s => s.Address),
             index: request.PageRequest.PageIndex,
             size: request.PageRequest.PageSize,
             cancellationToken: cancellationToken);


            GetListResponse<GetDynamicSellerResponse> response = _mapper.Map<GetListResponse<GetDynamicSellerResponse>>(seller);
            return response;
        }
    }
}
