using Application.Services.Repositories;
using Common.Events.User;
using Common.Models;
using MassTransit;
using MimeKit;
using NArchitecture.Core.Mailing;
using Projections.UserService.Contexts;
using Projections.UserService.Services;
using System.Linq.Dynamic.Core;

namespace Projections.UserService.Consumers;
public class UserAuthenticatorCodeConsumer : IConsumer<UserAuthenticatorCodeEvent>
{
    private readonly IConfiguration _configuration;
    private readonly ProjectionsUserDbContext _userDbContext;
    private readonly ILogger<UserAuthenticatorCodeConsumer> _logger;

    public UserAuthenticatorCodeConsumer(ILogger<UserAuthenticatorCodeConsumer> logger, ProjectionsUserDbContext userDbContext, IConfiguration configuration)
    {

        _logger = logger;
        _userDbContext = userDbContext;
        _configuration = configuration;
    }

    public async Task Consume(ConsumeContext<UserAuthenticatorCodeEvent> context)
    {
        var _entity = _userDbContext.Set<InboxEvent>();
        // if new request exists in inbox and processed then return true
        bool hasData = _entity.Where(i => i.EventId == context.Message.Id && i.Processed).Any();

        if (!hasData)
        {
            var toEmailList = new List<MailboxAddress> { new( name: context.Message.UserEmailAddress,
                                                          context.Message.UserEmailAddress) };

            MailService _mailService = new(_configuration);
            _mailService.SendMail(
                new Mail
                {
                    ToList = toEmailList,
                    Subject = "Authenticator Code - BorusanNext",
                    HtmlBody = $"Enter your authenticator code: {context.Message.AuthenticatorCode}"
                }
            );

            await _entity.AddAsync(new()
            {
                EventId = context.Message.Id,
                Processed = true
            });
            await _userDbContext.SaveChangesAsync();
            _logger.LogInformation(@$"EventId : {context.Message.Id} process edildi.");
        }

    }
}
