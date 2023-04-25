using eTaxi.Domain.Common;

namespace eTaxi.Domain
{
    public class File : BaseEntity
    {
        public int UserId { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public string OriginalName { get; set; }
        public string Type { get; set; } = string.Empty;

        public virtual User User { get; set; }
    }
}
