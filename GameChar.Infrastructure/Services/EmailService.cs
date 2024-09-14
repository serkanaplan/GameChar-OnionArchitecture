using GameChar.Application.Abstractions.Services;
using System.Net.Mail;

namespace GameChar.Infrastructure.Services
{
    public class EmailService(SmtpClient smtpClient) : IEmailService
    {
        private readonly SmtpClient _smtpClient = smtpClient;

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("no-reply@yourdomain.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(to);

            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
