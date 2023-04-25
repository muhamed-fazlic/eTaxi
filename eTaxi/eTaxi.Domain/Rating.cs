using eTaxi.Domain.Common;

namespace eTaxi.Domain
{
    public class Rating : BaseEntity
    {
        public Rating()
        {
            DateCreated = DateTime.Now;

        }
        public int UserId { get; set; }
        public int UserDriverId { get; set; }
        public int OrderId { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; } = string.Empty;

        public virtual User User { get; set; }
        public virtual User UserDriver { get; set; }
        public virtual Order Order { get; set; }
    }
}
