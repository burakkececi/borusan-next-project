using Application.Features.CustomerFavorites.Constants;
using Application.Features.CustomerFavorites.Constants;
using Application.Features.CustomerFavorites.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerFavorites.Constants.CustomerFavoritesOperationClaims;

namespace Application.Features.CustomerFavorites.Commands.Delete;

public class DeleteCustomerFavoriteCommand : IRequest<DeletedCustomerFavoriteResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, CustomerFavoritesOperationClaims.Delete];

    public class DeleteCustomerFavoriteCommandHandler : IRequestHandler<DeleteCustomerFavoriteCommand, DeletedCustomerFavoriteResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerFavoriteRepository _customerFavoriteRepository;
        private readonly CustomerFavoriteBusinessRules _customerFavoriteBusinessRules;

        public DeleteCustomerFavoriteCommandHandler(IMapper mapper, ICustomerFavoriteRepository customerFavoriteRepository,
                                         CustomerFavoriteBusinessRules customerFavoriteBusinessRules)
        {
            _mapper = mapper;
            _customerFavoriteRepository = customerFavoriteRepository;
            _customerFavoriteBusinessRules = customerFavoriteBusinessRules;
        }

        public async Task<DeletedCustomerFavoriteResponse> Handle(DeleteCustomerFavoriteCommand request, CancellationToken cancellationToken)
        {
            CustomerFavorite? customerFavorite = await _customerFavoriteRepository.GetAsync(predicate: cf => cf.Id == request.Id, cancellationToken: cancellationToken);
            await _customerFavoriteBusinessRules.CustomerFavoriteShouldExistWhenSelected(customerFavorite);

            await _customerFavoriteRepository.DeleteAsync(customerFavorite!);

            DeletedCustomerFavoriteResponse response = _mapper.Map<DeletedCustomerFavoriteResponse>(customerFavorite);
            return response;
        }
    }
}