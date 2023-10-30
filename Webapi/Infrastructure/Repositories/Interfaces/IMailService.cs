using Webapi.Model;

namespace Webapi.Infrastructure.Repositories.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
