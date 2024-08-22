using Application.Services.Repositories;
using Common.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Quartz;

namespace OutboxJobService.Jobs;
[DisallowConcurrentExecution]
public class OutboxEventJob : IJob
{
    private readonly ILogger<OutboxEventJob> _logger;
    private readonly BaseDbContext _context;
    private readonly IPublishEndpoint _publisher;

    public OutboxEventJob(ILogger<OutboxEventJob> logger, IPublishEndpoint publisher, BaseDbContext dispatcherContext)
    {
        _logger = logger;
        _publisher = publisher;
        _context = dispatcherContext;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var entity = _context.Set<OutboxEvent>();

        var messages = await entity
               .Where(x => x.State == OutboxEventState.ReadyToSend)
               .ToListAsync();

        foreach (var message in messages)
        {
            await _publisher.Publish(message.RecreateMessage());
            _logger.LogInformation("Event published");

            var record = await entity
                .FirstOrDefaultAsync(x => x.EventId == message.EventId);

            record!.ChangeState(OutboxEventState.SendToQueue);
            _context.SaveChanges();
            _logger.LogInformation("States updated");
        }
    }
}
