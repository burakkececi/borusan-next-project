using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Common.RabbitMQ;
using NArchitecture.Core.Mailing;
using Common.Consumers.User;

namespace Common
{
    public static class CommonServiceRegistration
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            services.AddSingleton<UserRegisterEventConsumer>(provider =>
            {
                var connectionFactory = new ConnectionFactory() { HostName = RabbitMQConstants.RabbitMQHost };
                var connection = connectionFactory.CreateConnection();
                var channel = connection.CreateModel();
                var mailService = provider.GetRequiredService<IMailService>();
                var queueName = RabbitMQConstants.UserRegisterQueueName;
                return new UserRegisterEventConsumer(channel, queueName, mailService);
            });

            return services;
        }
    }
}
