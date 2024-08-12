using Application.Features.CustomerFavorites.Constants;
using Application.Features.CustomerFavorites.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerFavorites.Constants.CustomerFavoritesOperationClaims;

namespace Application.Features.CustomerFavorites.Commands.Update;

public class UpdateCustomerFavoriteCommand : IRequest<UpdatedCustomerFavoriteResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required Guid CustomerId { get; set; }
    public required Guid AdvertId { get; set; }

    public string[] Roles => [Admin, Write, CustomerFavoritesOperationClaims.Update];

    public class UpdateCustomerFavoriteCommandHandler : IRequestHandler<UpdateCustomerFavoriteCommand, UpdatedCustomerFavoriteResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerFavoriteRepository _customerFavoriteRepository;
        private readonly CustomerFavoriteBusinessRules _customerFavoriteBusinessRules;

        public UpdateCustomerFavoriteCommandHandler(IMapper mapper, ICustomerFavoriteRepository customerFavoriteRepository,
                                         CustomerFavoriteBusinessRules customerFavoriteBusinessRules)
        {
            _mapper = mapper;
            _customerFavoriteRepository = customerFavoriteRepository;
            _customerFavoriteBusinessRules = customerFavoriteBusinessRules;
        }

        public async Task<UpdatedCustomerFavoriteResponse> Handle(UpdateCustomerFavoriteCommand request, CancellationToken cancellationToken)
        {
            CustomerFavorite? customerFavorite = await _customerFavoriteRepository.GetAsync(predicate: cf => cf.Id == request.Id, cancellationToken: cancellationToken);
            await _customerFavoriteBusinessRules.CustomerFavoriteShouldExistWhenSelected(customerFavorite);
            await _customerFavoriteBusinessRules.CustomerIdShouldExistWhenSelected(request.CustomerId, cancellationToken);
            await _customerFavoriteBusinessRules.AdvertIdShouldExistWhenSelected(request.AdvertId, cancellationToken);
            
            customerFavorite = _mapper.Map(request, customerFavorite);

            await _customerFavoriteRepository.UpdateAsync(customerFavorite!);

            UpdatedCustomerFavoriteResponse response = _mapper.Map<UpdatedCustomerFavoriteResponse>(customerFavorite);
            return response;
        }
    }
}