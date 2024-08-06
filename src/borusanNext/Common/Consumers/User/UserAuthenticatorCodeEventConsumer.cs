using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NArchitecture.Core.Mailing;
using MimeKit;
using Common.Events.User;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Web;
using Common.RabbitMQ;

namespace Common.Consumers.User;

public class UserAuthenticatorCodeEventConsumer
{
    private readonly IModel _channel;
    private readonly string _queueName;
    private readonly IMailService _mailService;

    public UserAuthenticatorCodeEventConsumer(IModel channel, string queueName, IMailService mailService)
    {
        _channel = channel;
        _queueName = queueName;
        _mailService = mailService;

        QueueFactory.EnsureExchange(_channel, RabbitMQConstants.UserExchangeName);
        QueueFactory.EnsureQueue(_channel, _queueName, RabbitMQConstants.UserExchangeName);
    }

    public void StartConsuming()
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += OnMessageReceived;

        _channel.BasicConsume(queue: _queueName,
                             autoAck: true,
                             consumer: consumer);

        Console.WriteLine("Tüketici çalışıyor...");
    }

    private void OnMessageReceived(object sender, BasicDeliverEventArgs ea)
    {
        try
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var userAuthenticatorCodeEvent = JsonSerializer.Deserialize<UserAuthenticatorCodeEvent>(message);

            if (userAuthenticatorCodeEvent != null)
                SendEmail(userAuthenticatorCodeEvent.UserEmailAdress, userAuthenticatorCodeEvent.AuthenticatorCode);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
    }

    private void SendEmail(string emailAddress, string authenticatorCode)
    {
        var toEmailList = new List<MailboxAddress> { new(name: emailAddress, emailAddress) };

        _mailService.SendMail(
            new Mail
            {
                ToList = toEmailList,
                Subject = "Authenticator Code - NArchitecture",
                HtmlBody = $"Enter your authenticator code: {authenticatorCode}"
            }
        );
    }
}
