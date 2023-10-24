using VacationRequester.Models.Dto;

namespace VacationRequester.Services.EmailService
{
    public interface IEmailService
    {
        Task SendEmail(EmailDto request);
    }
}
