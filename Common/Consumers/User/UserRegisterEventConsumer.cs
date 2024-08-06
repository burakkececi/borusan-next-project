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

namespace Common.Consumers.User;

public class UserRegisterEventConsumer
{
    private readonly IModel _channel;
    private readonly string _queueName;
    private readonly IMailService _mailService;

    public UserRegisterEventConsumer(IModel channel, string queueName, IMailService mailService)
    {
        _channel = channel;
        _queueName = queueName;
        _mailService = mailService;
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

            var userRegisterEvent = JsonSerializer.Deserialize<UserRegisterEvent>(message);

            if (userRegisterEvent != null)
                SendEmail(userRegisterEvent.UserEmailAdress);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
    }

    private void SendEmail(string emailAddress)
    {
        var mail = new Mail
        {
            ToList = new List<MailboxAddress> { new MailboxAddress("", emailAddress) },
            Subject = "Kayıt Onayı",
            HtmlBody = "Kayıt işleminiz başarıyla tamamlandı."
        };

        _mailService.SendMail(mail);
    }
}
