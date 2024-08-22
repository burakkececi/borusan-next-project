using MassTransit;
using Microsoft.EntityFrameworkCore;
using OutboxJobService.Jobs;
using Persistence.Contexts;
using Quartz;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<BaseDbContext>(options => options.UseNpgsql(hostContext.Configuration
                                                                            .GetConnectionString("BorusanNextLive")));

        services.AddQuartz(configurator =>
        {
            configurator.UseMicrosoftDependencyInjectionJobFactory();

            JobKey jobKey = new("OutboxEventPublishJob");

            #region Job Definitions
            configurator.AddJob<OutboxEventJob>(options => options.WithIdentity(jobKey));
            #endregion

            #region Triggers
            TriggerKey triggerKey = new("OutboxEventPublishTrigger");
            configurator.AddTrigger(options => options.ForJob(jobKey)
                        .WithIdentity(triggerKey)
                        .StartAt(DateTime.UtcNow)
                        .WithSimpleSchedule
                        (
                            builder => builder.WithIntervalInSeconds(5)
                                              .RepeatForever()
                        ));
            #endregion
        });

        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

        services.AddMassTransit(configurator =>
        {
            configurator.UsingRabbitMq((context, _configurator) =>
            {
                _configurator.Host(hostContext.Configuration["RabbitMQConfiguration:Host"], "/", hostConfigurator =>
                {
                    hostConfigurator.Username(hostContext.Configuration["RabbitMQConfiguration:Username"]);
                    hostConfigurator.Password(hostContext.Configuration["RabbitMQConfiguration:Password"]);
                });
            });
        });
    })
    .Build();

await host.RunAsync();