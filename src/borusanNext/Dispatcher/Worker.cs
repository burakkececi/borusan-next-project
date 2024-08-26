using Persistence.Contexts;

namespace OutboxJobService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly BaseDbContext _dbContext;

    public Worker(ILogger<Worker> logger, BaseDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            await Task.Delay(5000, stoppingToken);
        }
    }
}
