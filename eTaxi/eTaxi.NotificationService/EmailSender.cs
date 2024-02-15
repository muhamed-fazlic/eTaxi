using eTaxi.NotificationService.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace eTaxi.NotificationService
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get; set; }
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task<bool> SendEmailAsync(EmailMessage email)
        {
            using var client = new SmtpClient();
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(_emailSettings.From, _emailSettings.From));
                emailMessage.To.AddRange(email.To);
                emailMessage.Subject = email.Subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = email.Content };

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.CheckCertificateRevocation = false;
                client.Connect(_emailSettings.SmtpServer, _emailSettings.Port, _emailSettings.SSL == 0 ? false : true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailSettings.UserName, _emailSettings.Password);
                await client.SendAsync(emailMessage);
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception($"Error: {ex.Message}");
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
