using MassTransit;
using Microsoft.EntityFrameworkCore;
using Projections.FavoriteService.Consumers;
using Persistence.Contexts;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<BaseDbContext>(options =>
            options.UseNpgsql(hostContext.Configuration.GetConnectionString("DefaultConnection")));

        services.AddMassTransit(configurator =>
        {
            configurator.AddConsumer<CreateCustomerFavoriteConsumer>();
            configurator.AddConsumer<DeleteCustomerFavoriteConsumer>();
            configurator.AddConsumer<UpdateCustomerFavoriteConsumer>();

            configurator.UsingRabbitMq((context, rabbitMqConfig) =>
            {
                rabbitMqConfig.Host(hostContext.Configuration["RabbitMQConfiguration:Host"], "/", hostConfigurator =>
                {
                    hostConfigurator.Username(hostContext.Configuration["RabbitMQConfiguration:Username"]);
                    hostConfigurator.Password(hostContext.Configuration["RabbitMQConfiguration:Password"]);
                });

                rabbitMqConfig.ConfigureEndpoints(context);
            });
        });

        services.AddMassTransitHostedService();

        services.AddLogging();
    })
    .Build();

await host.RunAsync();
