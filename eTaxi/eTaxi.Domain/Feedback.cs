using eTaxi.Domain.Common;

namespace eTaxi.Domain
{
    public class Feedback : BaseEntity
    {
        public Feedback()
        {
            DateCreated = DateTime.Now;
            Files = new HashSet<File>();
        }
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public int OrderId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int Grade { get; set; }
        public ICollection<File> Files { get; set; }

        public virtual User User { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Order Order { get; set; }
    }
}
