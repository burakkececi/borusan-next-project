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

namespace Application.Features.CustomerFavorites.Commands.Create;

public class CreateCustomerFavoriteCommand : IRequest<Guid>, ISecuredRequest
{
    public required Guid CustomerId { get; set; }
    public required Guid AdvertId { get; set; }

    public string[] Roles => [Admin, Write, CustomerFavoritesOperationClaims.Create];

    public class CreateCustomerFavoriteCommandHandler : IRequestHandler<CreateCustomerFavoriteCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerFavoriteRepository _customerFavoriteRepository;
        private readonly CustomerFavoriteBusinessRules _customerFavoriteBusinessRules;
        private readonly IOutboxEventRepository _outboxEventRepository;

        public CreateCustomerFavoriteCommandHandler(IMapper mapper, ICustomerFavoriteRepository customerFavoriteRepository,
                                         CustomerFavoriteBusinessRules customerFavoriteBusinessRules, IOutboxEventRepository outboxEventRepository)
        {
            _mapper = mapper;
            _customerFavoriteRepository = customerFavoriteRepository;
            _customerFavoriteBusinessRules = customerFavoriteBusinessRules;
            _outboxEventRepository = outboxEventRepository;
        }

        public async Task<Guid> Handle(CreateCustomerFavoriteCommand request, CancellationToken cancellationToken)
        {
            CustomerFavorite customerFavorite = _mapper.Map<CustomerFavorite>(request);
            await _customerFavoriteBusinessRules.CustomerIdShouldExistWhenSelected(request.CustomerId, cancellationToken);
            await _customerFavoriteBusinessRules.AdvertIdShouldExistWhenSelected(request.AdvertId, cancellationToken);

            var favId = Guid.NewGuid();
            var @event = new CreateCustomerFavoriteEvent()
            {
                Id = Guid.NewGuid(),
                CustomerFavoriteId = favId,
                CustomerId = customerFavorite.CustomerId,
                AdvertId = customerFavorite.AdvertId
            };

            OutboxEvent outboxEvent = new(@event, @event.Id, DateTime.Now.ToUniversalTime());
            await _outboxEventRepository.AddAsync(outboxEvent);
            await _outboxEventRepository.SaveChangesAsync();

            return favId;
        }
    }
}