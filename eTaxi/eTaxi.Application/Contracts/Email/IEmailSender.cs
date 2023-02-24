using eTaxi.Application.Models.Email;

namespace eTaxi.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(EmailMessage email);
    }
}
