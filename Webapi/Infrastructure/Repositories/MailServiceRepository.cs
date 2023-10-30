using Microsoft.Extensions.Options;
using Webapi.Infrastructure.Repositories.Interfaces;
using Webapi.Model;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
namespace Webapi.Infrastructure.Repositories
{
    public class MailServiceRepository : IMailService
    {
        private readonly DataContext _context;
        private readonly MailSettings _mailSettings;
        public MailServiceRepository(DataContext dataContext, MailSettings mailSettings)
        {
            _context = dataContext;
            _mailSettings = mailSettings;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test Project", "FromEmail@gmail.com"));
            message.To.Add(new MailboxAddress("pritom", "ToEmail@gmail.com"));
            message.Subject = "Hi,this is demo email";
            message.Body = new TextPart("plain")
            {
                Text = "Hello ,You've been assigned new engagement <engagement id>: <client name> for <audit type> audit. \r\nThanks,\r\nTeam Bootcamp",
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("FromEmail300@gmail.com", "YourPassword");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
