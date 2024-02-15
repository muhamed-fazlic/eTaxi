using eTaxi.NotificationService.Models;

namespace eTaxi.NotificationService
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(EmailMessage email);
    }
}
