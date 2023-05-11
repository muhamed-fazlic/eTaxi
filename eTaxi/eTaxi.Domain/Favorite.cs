using eTaxi.Domain.Common;

namespace eTaxi.Domain
{
    public class Favorite : BaseEntity
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }

        public virtual User User { get; set; }
        public virtual Company Company { get; set; }
    }
}
