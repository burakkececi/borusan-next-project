using MimeKit.Cryptography;
using MimeKit;
using NArchitecture.Core.Mailing;
using Org.BouncyCastle.Crypto;
using MailKit.Net.Smtp;
using Org.BouncyCastle.OpenSsl;

namespace Projections.UserService.Services;
public class MailService
{
    private readonly IConfiguration _configuration;

    public MailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SendMail(Mail mail)
    {
        if (mail.ToList == null || mail.ToList.Count < 1)
            return;
        emailPrepare(mail, email: out MimeMessage email, smtp: out SmtpClient smtp);
        smtp.Send(email);
        smtp.Disconnect(true);
        email.Dispose();
        smtp.Dispose();
    }

    public async Task SendEmailAsync(Mail mail)
    {
        if (mail.ToList == null || mail.ToList.Count < 1)
            return;
        emailPrepare(mail, email: out MimeMessage email, smtp: out SmtpClient smtp);
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
        email.Dispose();
        smtp.Dispose();
    }

    private void emailPrepare(Mail mail, out MimeMessage email, out SmtpClient smtp)
    {
        email = new MimeMessage();
        email.From.Add(new MailboxAddress(_configuration["MailSettings:SenderFullName"],
                                          _configuration["MailSettings:SenderEmail"]));
        email.To.AddRange(mail.ToList);
        if (mail.CcList != null && mail.CcList.Any())
            email.Cc.AddRange(mail.CcList);
        if (mail.BccList != null && mail.BccList.Any())
            email.Bcc.AddRange(mail.BccList);

        email.Subject = mail.Subject;
        if (mail.UnsubscribeLink != null)
            email.Headers.Add(field: "List-Unsubscribe", value: $"<{mail.UnsubscribeLink}>");
        BodyBuilder bodyBuilder = new() { TextBody = mail.TextBody, HtmlBody = mail.HtmlBody };

        if (mail.Attachments != null)
            foreach (MimeEntity? attachment in mail.Attachments)
                if (attachment != null)
                    bodyBuilder.Attachments.Add(attachment);

        email.Body = bodyBuilder.ToMessageBody();
        email.Prepare(EncodingConstraint.SevenBit);

        if (_configuration["MailSettings:DkimPrivateKey"] != null && _configuration["MailSettings:DkimSelector"] != null && _configuration["MailSettings:DomainName"] != null)
        {
            DkimSigner signer =
                new(key: readPrivateKeyFromPemEncodedString(), _configuration["MailSettings:DomainName"], _configuration["MailSettings:DkimSelector"])
                {
                    HeaderCanonicalizationAlgorithm = DkimCanonicalizationAlgorithm.Simple,
                    BodyCanonicalizationAlgorithm = DkimCanonicalizationAlgorithm.Simple,
                    AgentOrUserIdentifier = $"@{_configuration["MailSettings:DomainName"]}",
                    QueryMethod = "dns/txt"
                };
            HeaderId[] headers = { HeaderId.From, HeaderId.Subject, HeaderId.To };
            signer.Sign(email, headers);
        }

        smtp = new SmtpClient();
        smtp.Connect(_configuration["MailSettings:Server"], Convert.ToInt32(_configuration["MailSettings:Port"]));
        if (Convert.ToBoolean(_configuration["MailSettings:AuthenticationRequired"]))
            smtp.Authenticate(_configuration["MailSettings:UserName"], _configuration["MailSettings:Password"]);
    }

    private AsymmetricKeyParameter readPrivateKeyFromPemEncodedString()
    {
        AsymmetricKeyParameter result;
        string pemEncodedKey =
            "-----BEGIN RSA PRIVATE KEY-----\n" + _configuration["MailSettings:DkimPrivateKey"] + "\n-----END RSA PRIVATE KEY-----";
        using (StringReader stringReader = new(pemEncodedKey))
        {
            PemReader pemReader = new(stringReader);
            object? pemObject = pemReader.ReadObject();
            result = ((AsymmetricCipherKeyPair)pemObject).Private;
        }

        return result;
    }
}
