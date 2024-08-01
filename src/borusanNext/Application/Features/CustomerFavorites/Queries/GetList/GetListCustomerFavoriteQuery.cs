using Application.Features.CustomerFavorites.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CustomerFavorites.Constants.CustomerFavoritesOperationClaims;

namespace Application.Features.CustomerFavorites.Queries.GetList;

public class GetListCustomerFavoriteQuery : IRequest<GetListResponse<GetListCustomerFavoriteListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListCustomerFavoriteQueryHandler : IRequestHandler<GetListCustomerFavoriteQuery, GetListResponse<GetListCustomerFavoriteListItemDto>>
    {
        private readonly ICustomerFavoriteRepository _customerFavoriteRepository;
        private readonly IMapper _mapper;

        public GetListCustomerFavoriteQueryHandler(ICustomerFavoriteRepository customerFavoriteRepository, IMapper mapper)
        {
            _customerFavoriteRepository = customerFavoriteRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerFavoriteListItemDto>> Handle(GetListCustomerFavoriteQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerFavorite> customerFavorites = await _customerFavoriteRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCustomerFavoriteListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerFavoriteListItemDto>>(customerFavorites);
            return response;
        }
    }
}