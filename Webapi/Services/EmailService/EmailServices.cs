using CodePulse.API.Models.DTO;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace CodePulse.API.Services.EmailService
{
    public class EmailServices : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailServices(IConfiguration config)
        {
            _config = config;
        }
        public Task SendEmail(EmailDto emailRequest)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(emailRequest.To));
            email.Subject = emailRequest.Subject;

            email.Body = new TextPart("plain")
            {
                Text = "Hello ,You've been assigned new engagement <engagement id>: <client name> for <audit type> audit. \r\nThanks,\r\nTeam Bootcamp",
            };

            //email.Body = new TextPart(TextFormat.Html) { Text = emailRequest.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls); //For testing only need to replace 
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

            return Task.CompletedTask;
        }
    }
}
