using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using VacationRequester.Models.Dto;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;

namespace VacationRequester.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public Task SendEmail(EmailDto request)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("elliot.weber@ethereal.email"));
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                email.Body = new TextPart(TextFormat.Text) { Text = request.Body };

                using var smtp = new SmtpClient();
                smtp.CheckCertificateRevocation = false;
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                smtp.Authenticate(_config["EmailConfig:UserName"], _config["EmailConfig:Password"]);
                smtp.Send(email);
                smtp.Disconnect(true);

                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                e.Data.Add("EmailService", "SendEmail");
                return Task.FromException(e);
            }

        }
    }
}
