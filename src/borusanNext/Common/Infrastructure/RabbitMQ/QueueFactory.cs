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
            var channel = CreateBasicConsumer()
                                .EnsureExchange(exchangeName, exchangeType)
                                .EnsureQueue(queueName, exchangeName)
                                .Model;

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

        public static EventingBasicConsumer EnsureExchange(this EventingBasicConsumer consumer,
                                          string exchangeName,
                                          string exchangeType = RabbitMQConstants.DefaultExchangeType)
        {
            consumer.Model.ExchangeDeclare(exchange: exchangeName,
                                           type: exchangeType,
                                           durable: false,
                                           autoDelete: false);

            return consumer;
        }

        public static EventingBasicConsumer EnsureQueue(this EventingBasicConsumer consumer,
                                       string queueName,
                                       string exchangeName)
        {
            consumer.Model.QueueDeclare(queue: queueName,
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

            consumer.Model.QueueBind(queueName, exchangeName, queueName);

            return consumer;
        }

        public static EventingBasicConsumer CreateBasicConsumer()
        {
            var factory = new ConnectionFactory() { HostName = RabbitMQConstants.RabbitMQHost };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            return new EventingBasicConsumer(channel);
        }
    }
}
