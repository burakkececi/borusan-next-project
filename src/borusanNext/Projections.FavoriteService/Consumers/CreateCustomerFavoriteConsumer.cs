using Common.Events.CustomerFavorite;
using Common.Models;
using Domain.Entities;
using MassTransit;
using Microsoft.Extensions.Configuration;
using MimeKit;
using NArchitecture.Core.Mailing;
using Persistence.Contexts;

namespace Projections.FavoriteService.Consumers;
public class CreateCustomerFavoriteConsumer : IConsumer<CreateCustomerFavoriteEvent>
{
    private readonly ILogger<CreateCustomerFavoriteConsumer> _logger;
    private readonly BaseDbContext _projectionContext;

    public CreateCustomerFavoriteConsumer(ILogger<CreateCustomerFavoriteConsumer> logger, BaseDbContext projectionContext)
    {
        _logger = logger;
        _projectionContext = projectionContext;
    }

    public async Task Consume(ConsumeContext<CreateCustomerFavoriteEvent> context)
    {

        var _entity = _projectionContext.Set<InboxEvent>();
        bool hasData = _entity.Where(i => i.EventId == context.Message.Id && i.Processed).Any();

        if (!hasData)
        {
            var entity = _projectionContext.Set<CustomerFavorite>();

            await entity.AddAsync(new()
            {
                Id = context.Message.Id,
                AdvertId = context.Message.AdvertId,
                CustomerId = context.Message.CustomerId
            });

            await _entity.AddAsync(new()
            {
                EventId = context.Message.Id,
                Processed = true
            });
            await _projectionContext.SaveChangesAsync();
            _logger.LogInformation(@$"EventId : {context.Message.Id} process edildi.");
        }
    }
}
