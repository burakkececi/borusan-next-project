using Application.Services.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Mailing;
using Persistence.Repositories;
using Projections.UserService;
using Projections.UserService.Consumers;
using Projections.UserService.Contexts;
using Projections.UserService.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddTransient<MailService>();

        services.AddMassTransit(configurator =>
        {
            services.AddDbContext<ProjectionsUserDbContext>(options => options.UseNpgsql(hostContext.Configuration
                                                                            .GetConnectionString("DefaultConnection")));

            configurator.AddConsumer<UserAuthenticatorCodeConsumer>();
            configurator.AddConsumer<UserRegisterVerificationConsumer>();

            configurator.UsingRabbitMq((context, _configurator) =>
            {
                _configurator.Host(hostContext.Configuration["RabbitMQConfiguration:Host"], "/", hostConfigurator =>
                {
                    hostConfigurator.Username(hostContext.Configuration["RabbitMQConfiguration:Username"]);
                    hostConfigurator.Password(hostContext.Configuration["RabbitMQConfiguration:Password"]);
                });

                _configurator.ConfigureEndpoints(context); // Automatically configure endpoints for consumers
            });
        });

        services.AddLogging();

    }).Build();

await host.RunAsync();