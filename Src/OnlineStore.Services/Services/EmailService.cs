using System.Net;
using System.Net.Mail;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Infra.Configuration;

namespace OnlineStore.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        public EmailService()
        {
            _smtpClient = new SmtpClient(AppConfiguration.SMTP.Host)
            {
                Port = AppConfiguration.SMTP.Port,
                Credentials = new NetworkCredential(AppConfiguration.SMTP.Username, AppConfiguration.SMTP.Password),
                EnableSsl = true
            };
        }

        public bool SendEmail(string from, string to, string title, string message)
        {
            try
            {
                _smtpClient.Send(from, to, title, message);
                return true;

            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Some arguments are missing");
            }
            catch (SmtpException ex)
            {

                throw new SmtpException($"The email handler returned a exception - {ex.Message}");
            }

        }
    }
}
