using Application.Features.CustomerFavorites.Constants;
using Application.Features.CustomerFavorites.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerFavorites.Constants.CustomerFavoritesOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CustomerFavorites.Queries.GetById;

public class GetByIdCustomerFavoriteQuery : IRequest<GetByIdCustomerFavoriteResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCustomerFavoriteQueryHandler : IRequestHandler<GetByIdCustomerFavoriteQuery, GetByIdCustomerFavoriteResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerFavoriteRepository _customerFavoriteRepository;
        private readonly CustomerFavoriteBusinessRules _customerFavoriteBusinessRules;

        public GetByIdCustomerFavoriteQueryHandler(IMapper mapper, ICustomerFavoriteRepository customerFavoriteRepository, CustomerFavoriteBusinessRules customerFavoriteBusinessRules)
        {
            _mapper = mapper;
            _customerFavoriteRepository = customerFavoriteRepository;
            _customerFavoriteBusinessRules = customerFavoriteBusinessRules;
        }

        public async Task<GetByIdCustomerFavoriteResponse> Handle(GetByIdCustomerFavoriteQuery request, CancellationToken cancellationToken)
        {
            CustomerFavorite? customerFavorite = await _customerFavoriteRepository.GetAsync(predicate: cf => cf.Id == request.Id, include: i => i.Include(c => c.Customer).Include(c => c.Advert),
 cancellationToken: cancellationToken);
            await _customerFavoriteBusinessRules.CustomerFavoriteShouldExistWhenSelected(customerFavorite);

            GetByIdCustomerFavoriteResponse response = _mapper.Map<GetByIdCustomerFavoriteResponse>(customerFavorite);
            return response;
        }
    }
}