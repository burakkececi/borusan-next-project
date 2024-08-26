using Common.Events.CustomerFavorite;
using Common.Models;
using Domain.Entities;
using MassTransit;
using Persistence.Contexts;

namespace Projections.FavoriteService.Consumers;
public class UpdateCustomerFavoriteConsumer : IConsumer<UpdateCustomerFavoriteEvent>
{
    private readonly ILogger<UpdateCustomerFavoriteEvent> _logger;
    private readonly BaseDbContext _projectionContext;

    public UpdateCustomerFavoriteConsumer(ILogger<UpdateCustomerFavoriteEvent> logger, BaseDbContext projectionContext)
    {
        _logger = logger;
        _projectionContext = projectionContext;
    }

    public async Task Consume(ConsumeContext<UpdateCustomerFavoriteEvent> context)
    {
        var _inbox = _projectionContext.Set<InboxEvent>();
        bool hasData = _inbox.Where(i => i.EventId == context.Message.Id && i.Processed).Any();

        if (!hasData)
        {
            var entity = _projectionContext.Set<CustomerFavorite>();

            entity.Update(new()
            {
                Id = context.Message.CustomerFavoriteId,
                AdvertId = context.Message.AdvertId,
                CustomerId = context.Message.CustomerId
            });

            await _inbox.AddAsync(new()
            {
                EventId = context.Message.Id,
                Processed = true
            });
            await _projectionContext.SaveChangesAsync();
            _logger.LogInformation(@$"EventId : {context.Message.Id} process edildi.");
        }
    }
}
