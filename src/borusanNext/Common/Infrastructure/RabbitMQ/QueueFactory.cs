using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;

namespace Common.Infrastructure.RabbitMQ
{
    public static class QueueFactory
    {
        public static void SendMessageToExchange(string exchangeName, string exchangeType, string queueName, object obj)
        {
            using var connection = CreateConnection();
            using var channel = connection.CreateModel();

            EnsureExchange(channel, exchangeName, exchangeType);
            EnsureQueue(channel, queueName, exchangeName);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));

            channel.BasicPublish(exchange: exchangeName,
                                 routingKey: queueName,
                                 basicProperties: null,
                                 body: body);
        }

        public static IConnection CreateConnection()
        {
            var factory = new ConnectionFactory() { HostName = RabbitMQConstants.RabbitMQHost };
            return factory.CreateConnection();
        }

        public static void EnsureExchange(IModel channel, string exchangeName, string exchangeType = RabbitMQConstants.DefaultExchangeType)
        {
            channel.ExchangeDeclare(exchange: exchangeName, type: exchangeType, durable: false, autoDelete: false);
        }

        public static void EnsureQueue(IModel channel, string queueName, string exchangeName)
        {
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.QueueBind(queueName, exchangeName, queueName);
        }

        public static EventingBasicConsumer CreateConsumer(IModel channel)
        {
            return new EventingBasicConsumer(channel);
        }
    }
}
