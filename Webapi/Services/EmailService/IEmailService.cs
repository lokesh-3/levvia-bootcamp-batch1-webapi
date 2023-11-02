using CodePulse.API.Models.DTO;

namespace CodePulse.API.Services.EmailService
{
    public interface IEmailService
    {
        Task SendEmail(EmailDto emailRequest);
    }
}
