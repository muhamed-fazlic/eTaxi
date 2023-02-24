using MimeKit;

namespace eTaxi.Application.Models.Email
{
    public class EmailMessage
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public EmailMessage(IEnumerable<string> to, string subject, string content)
        {
            if (to.Count() > 0 && !string.IsNullOrEmpty(content))
            {
                To = new List<MailboxAddress>();

                To.AddRange(to.Select(x => new MailboxAddress(x, x)));
                Subject = subject;
                Content = content;
            }
        }
    }
}
