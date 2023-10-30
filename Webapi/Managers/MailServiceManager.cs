using Webapi.Infrastructure.Repositories;
using Webapi.Infrastructure.Repositories.Interfaces;
using Webapi.Model;

namespace Webapi.Managers
{
    public class MailServiceManager
    {
        private readonly IMailService _mailService;
      

        public MailServiceManager(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
             await _mailService.SendEmailAsync(mailRequest);
        }

    }
}
