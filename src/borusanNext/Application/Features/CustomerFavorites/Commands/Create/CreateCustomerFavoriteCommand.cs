using Application.Features.CustomerFavorites.Constants;
using Application.Features.CustomerFavorites.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerFavorites.Constants.CustomerFavoritesOperationClaims;

namespace Application.Features.CustomerFavorites.Commands.Create;

public class CreateCustomerFavoriteCommand : IRequest<CreatedCustomerFavoriteResponse>, ISecuredRequest
{
    public required Guid CustomerId { get; set; }
    public required Guid AdvertId { get; set; }

    public string[] Roles => [Admin, Write, CustomerFavoritesOperationClaims.Create];

    public class CreateCustomerFavoriteCommandHandler : IRequestHandler<CreateCustomerFavoriteCommand, CreatedCustomerFavoriteResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerFavoriteRepository _customerFavoriteRepository;
        private readonly CustomerFavoriteBusinessRules _customerFavoriteBusinessRules;

        public CreateCustomerFavoriteCommandHandler(IMapper mapper, ICustomerFavoriteRepository customerFavoriteRepository,
                                         CustomerFavoriteBusinessRules customerFavoriteBusinessRules)
        {
            _mapper = mapper;
            _customerFavoriteRepository = customerFavoriteRepository;
            _customerFavoriteBusinessRules = customerFavoriteBusinessRules;
        }

        public async Task<CreatedCustomerFavoriteResponse> Handle(CreateCustomerFavoriteCommand request, CancellationToken cancellationToken)
        {
            CustomerFavorite customerFavorite = _mapper.Map<CustomerFavorite>(request);

            await _customerFavoriteRepository.AddAsync(customerFavorite);

            CreatedCustomerFavoriteResponse response = _mapper.Map<CreatedCustomerFavoriteResponse>(customerFavorite);
            return response;
        }
    }
}