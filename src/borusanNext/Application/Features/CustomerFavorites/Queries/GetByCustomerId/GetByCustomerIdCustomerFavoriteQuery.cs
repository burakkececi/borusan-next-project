using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.CustomerFavorites.Constants.CustomerFavoritesOperationClaims;

namespace Application.Features.CustomerFavorites.Queries.GetByCustomerId;
public class GetByCustomerIdCustomerFavoriteQuery : IRequest<GetListResponse<GetByCustomerIdCustomerFavoriteListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public Guid CustomerId { get; set; }
    public string[] Roles => [Admin, Read];

    public class GetByCustomerIdCustomerFavoriteQueryHandler : IRequestHandler<GetByCustomerIdCustomerFavoriteQuery, GetListResponse<GetByCustomerIdCustomerFavoriteListItemDto>>
    {
        private readonly ICustomerFavoriteRepository _customerFavoriteRepository;
        private readonly IAdvertImageRepository _advertImageRepository;
        private readonly IMapper _mapper;

        public GetByCustomerIdCustomerFavoriteQueryHandler(ICustomerFavoriteRepository customerFavoriteRepository, IMapper mapper, IAdvertImageRepository advertImageRepository)
        {
            _customerFavoriteRepository = customerFavoriteRepository;
            _mapper = mapper;
            _advertImageRepository = advertImageRepository;
        }

        public async Task<GetListResponse<GetByCustomerIdCustomerFavoriteListItemDto>> Handle(GetByCustomerIdCustomerFavoriteQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CustomerFavorite> customerFavorites = await _customerFavoriteRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                predicate: i => i.CustomerId == request.CustomerId,
                include: i => i.Include(c => c.Customer)
                               .Include(c => c.Advert)
                                .ThenInclude(c => c.Car)
                                .ThenInclude(c => c.ModalExtension)
                                .ThenInclude(c => c.CarModel)
                                .ThenInclude(c => c.Brand),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetByCustomerIdCustomerFavoriteListItemDto> response = _mapper.Map<GetListResponse<GetByCustomerIdCustomerFavoriteListItemDto>>(customerFavorites);

            return response;
        }
    }
}
