using MailKit;
using MediatR;
using MimeKit;
using NArchitecture.Core.Mailing;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using IMailService = NArchitecture.Core.Mailing.IMailService;

namespace Application.Features.MailSender
{
    public class MailSenderCommand : IRequest<bool>
    {
        public List<string> ToEmailList { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }

    public class MailSenderCommandHandler : IRequestHandler<MailSenderCommand, bool>
    {
        private readonly IMailService _mailService;

        public MailSenderCommandHandler(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async Task<bool> Handle(MailSenderCommand request, CancellationToken cancellationToken)
        {
            var toEmailList = new List<MailboxAddress>();

            foreach (var toEmail in request.ToEmailList)
            {
                toEmailList.Add(new(name: toEmail, toEmail));
            }

            _mailService.SendMail(
                new Mail
                {
                    ToList = toEmailList,
                    Subject = request.Subject,
                    HtmlBody = request.Body
                }
            );

            return true;
        }
    }
}