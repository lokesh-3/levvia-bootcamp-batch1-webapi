using DTO;
using Microsoft.Extensions.Configuration;
using Services.Interface;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Services.ServicesRepos
{
    public class EmailServices : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailServices(IConfiguration config)
        {
            _config = config;
        }
        //public Task SendEmail(EmailDto emailRequest)
        //{
        //    var email = new MimeMessage();
        //    email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
        //    email.To.Add(MailboxAddress.Parse(emailRequest.To));
        //    //email.Subject = emailRequest.Subject;
        //    email.Subject = "Auditor Assignment Confirmation";

        //    email.Body = new TextPart("plain")
        //    {
        //        Text = "Hello ,You've been assigned new engagement <engagement id>: <client name> for <audit type> audit. \r\nThanks,\r\nTeam Bootcamp",
        //    };

        //    //email.Body = new TextPart(TextFormat.Html) { Text = emailRequest.Body };

        //    using var smtp = new SmtpClient();
        //    smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
        //    smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
        //    smtp.Send(email);
        //    smtp.Disconnect(true);

        //    return Task.CompletedTask;
        //}
        public Task SendEmail(EmailDto emailRequest)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            
            foreach (var toAddress in emailRequest.To)
            {
                email.To.Add(MailboxAddress.Parse(toAddress.Trim()));
            }
            email.Subject = "Auditor Assignment Confirmation";

            email.Body = new TextPart("plain")
            {
                Text = "Hello ,You've been assigned new engagement <engagement id>: <client name> for <audit type> audit. \r\nThanks,\r\nTeam Bootcamp",
            };

            //email.Body = new TextPart(TextFormat.Html) { Text = emailRequest.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

            return Task.CompletedTask;
        }

    }
}
