using Application.Features.CustomerFavorites.Constants;
using Application.Features.CustomerFavorites.Constants;
using Application.Features.CustomerFavorites.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerFavorites.Constants.CustomerFavoritesOperationClaims;
using Common.Events.CustomerFavorite;
using Common.Models;

namespace Application.Features.CustomerFavorites.Commands.Delete;

public class DeleteCustomerFavoriteCommand : IRequest<Unit>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, CustomerFavoritesOperationClaims.Delete];

    public class DeleteCustomerFavoriteCommandHandler : IRequestHandler<DeleteCustomerFavoriteCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerFavoriteRepository _customerFavoriteRepository;
        private readonly CustomerFavoriteBusinessRules _customerFavoriteBusinessRules;
        private readonly IOutboxEventRepository _outboxEventRepository;

        public DeleteCustomerFavoriteCommandHandler(IMapper mapper, ICustomerFavoriteRepository customerFavoriteRepository,
                                         CustomerFavoriteBusinessRules customerFavoriteBusinessRules, IOutboxEventRepository outboxEventRepository)
        {
            _mapper = mapper;
            _customerFavoriteRepository = customerFavoriteRepository;
            _customerFavoriteBusinessRules = customerFavoriteBusinessRules;
            _outboxEventRepository = outboxEventRepository;
        }

        public async Task<Unit> Handle(DeleteCustomerFavoriteCommand request, CancellationToken cancellationToken)
        {
            CustomerFavorite? customerFavorite = await _customerFavoriteRepository.GetAsync(predicate: cf => cf.Id == request.Id, cancellationToken: cancellationToken);
            await _customerFavoriteBusinessRules.CustomerFavoriteShouldExistWhenSelected(customerFavorite);

            var @event = new DeleteCustomerFavoriteEvent()
            {
                Id = customerFavorite.Id,
                CustomerId = customerFavorite.CustomerId,
                AdvertId = customerFavorite.AdvertId
            };

            OutboxEvent outboxEvent = new(@event, @event.Id, DateTime.Now.ToUniversalTime());
            await _outboxEventRepository.AddAsync(outboxEvent);
            await _outboxEventRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}