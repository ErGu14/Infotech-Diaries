using ECommerce.Business.Abstract;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer = "mail.enginniyazi.com"; // SMTP sunucusu
        private readonly int _smtpPort = 587; // SMTP portu
        private readonly string _smtpUser = "info@enginniyazi.com"; // SMTP kullanıcı adı
        private readonly string _smtpPass = "34JKnLMNa4eeAp4"; // SMTP şifresi

        //API KEY: 7c1597285bcd479d0bf1066b370945f7
        //API SECRET: d28aae6bb61ebb605f5d59cab85125ca

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(_smtpUser, _smtpPass);
                smtpClient.EnableSsl = false;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpUser),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}