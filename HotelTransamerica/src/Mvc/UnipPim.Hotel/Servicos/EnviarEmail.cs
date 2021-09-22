using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;

namespace UnipPim.Hotel.Servicos
{
    public class EnviarEmail : IEmailSender
    {
        private readonly SmtpClient _smtp;
        private readonly IConfiguration _configuration;

        public EnviarEmail(SmtpClient smtp, IConfiguration configuration)
        {
            _smtp = smtp;
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(_configuration.GetValue<string>("Email:UserName"));
            message.To.Add(email);
            message.Subject = subject;
            message.Body = htmlMessage;
            message.IsBodyHtml = true;

            await _smtp.SendMailAsync(message);
        }
    }
}
