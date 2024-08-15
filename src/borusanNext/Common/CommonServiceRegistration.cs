using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using NArchitecture.Core.Mailing;
using Microsoft.AspNetCore.Builder;
using Common.Infrastructure.RabbitMQ;
using Common.Infrastructure.Consumers.User;

namespace Common
{
    public static class CommonServiceRegistration
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            services.AddSingleton<UserRegisterVerificationEventConsumer>(provider =>
            {
                var connectionFactory = new ConnectionFactory() { HostName = RabbitMQConstants.RabbitMQHost };
                var connection = connectionFactory.CreateConnection();
                var channel = connection.CreateModel();
                var mailService = provider.GetRequiredService<IMailService>();
                var queueName = RabbitMQConstants.UserRegisterVerificationQueueName;
                return new UserRegisterVerificationEventConsumer(channel, queueName, mailService);
            });

            services.AddSingleton<UserAuthenticatorCodeEventConsumer>(provider =>
            {
                var connectionFactory = new ConnectionFactory() { HostName = RabbitMQConstants.RabbitMQHost };
                var connection = connectionFactory.CreateConnection();
                var channel = connection.CreateModel();
                var mailService = provider.GetRequiredService<IMailService>();
                var queueName = RabbitMQConstants.UserRegisterAuthenticatorCodeQueueName;
                return new UserAuthenticatorCodeEventConsumer(channel, queueName, mailService);
            });

            return services;
        }

        public static IApplicationBuilder AddConsumerStart(this IApplicationBuilder app)
        {
            // User Register Consumer
            var userRegisterConsumer = app.ApplicationServices.GetService<UserRegisterVerificationEventConsumer>();
            userRegisterConsumer?.StartConsuming();

            // User Authenticator Code Consumer
            var userAuthenticatorCodeConsumer = app.ApplicationServices.GetService<UserAuthenticatorCodeEventConsumer>();
            userAuthenticatorCodeConsumer?.StartConsuming();

            return app;
        }
    }
}
