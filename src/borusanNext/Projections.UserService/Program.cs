using MassTransit;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Mailing.MailKit;
using Persistence.Contexts;
using Persistence.Repositories;
using Projections.UserService;
using Projections.UserService.Consumers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddScoped<IMailService, MailKitMailService>(_ => new MailKitMailService(hostContext.Configuration.GetSection("MailSettings").Get<MailSettings>()));
        services.AddDbContext<BaseDbContext>(options => options.UseNpgsql(hostContext.Configuration
                                                                            .GetConnectionString("BorusanNextLive")));

        services.AddMassTransit(configurator =>
        {
            configurator.AddConsumer<UserAuthenticatorCodeConsumer>();
            configurator.AddConsumer<UserRegisterVerificationConsumer>();

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

    }).Build();

await host.RunAsync();