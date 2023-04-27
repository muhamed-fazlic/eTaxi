using eTaxi.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTaxi.Domain
{
    public class File : BaseEntity
    {
        public int UserId { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public string OriginalName { get; set; }
        public string Type { get; set; } = string.Empty;

        public int? FeedbackId { get; set; }
        public virtual Feedback Feedback { get; set; }
        public virtual User User { get; set; }
    }
}
