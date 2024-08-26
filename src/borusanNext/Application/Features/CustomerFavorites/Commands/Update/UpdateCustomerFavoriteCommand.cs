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

namespace Application.Features.CustomerFavorites.Commands.Update;

public class UpdateCustomerFavoriteCommand : IRequest<Unit>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required Guid CustomerId { get; set; }
    public required Guid AdvertId { get; set; }

    public string[] Roles => [Admin, Write, CustomerFavoritesOperationClaims.Update];

    public class UpdateCustomerFavoriteCommandHandler : IRequestHandler<UpdateCustomerFavoriteCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerFavoriteRepository _customerFavoriteRepository;
        private readonly CustomerFavoriteBusinessRules _customerFavoriteBusinessRules;
        private readonly IOutboxEventRepository _outboxEventRepository;

        public UpdateCustomerFavoriteCommandHandler(IMapper mapper, ICustomerFavoriteRepository customerFavoriteRepository,
                                         CustomerFavoriteBusinessRules customerFavoriteBusinessRules, IOutboxEventRepository outboxEventRepository)
        {
            _mapper = mapper;
            _customerFavoriteRepository = customerFavoriteRepository;
            _customerFavoriteBusinessRules = customerFavoriteBusinessRules;
            _outboxEventRepository = outboxEventRepository;
        }

        public async Task<Unit> Handle(UpdateCustomerFavoriteCommand request, CancellationToken cancellationToken)
        {
            CustomerFavorite? customerFavorite = await _customerFavoriteRepository.GetAsync(predicate: cf => cf.Id == request.Id, cancellationToken: cancellationToken);
            await _customerFavoriteBusinessRules.CustomerFavoriteShouldExistWhenSelected(customerFavorite);
            await _customerFavoriteBusinessRules.CustomerIdShouldExistWhenSelected(request.CustomerId, cancellationToken);
            await _customerFavoriteBusinessRules.AdvertIdShouldExistWhenSelected(request.AdvertId, cancellationToken);

            customerFavorite = _mapper.Map(request, customerFavorite);

            var @event = new UpdateCustomerFavoriteEvent()
            {
                Id = Guid.NewGuid(),
                CustomerFavoriteId = customerFavorite.Id,
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