using eTaxi.Domain.Common;

namespace eTaxi.Domain
{
    public class Order : BaseEntity
    {
        public Order()
        {
            IsActive = true;
            DateCreated = DateTime.Now;
        }

        public bool IsActive { get; set; }
        public int UserDriverId { get; set; }
        public int? UserId { get; set; }
        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }
        public int VehicleId { get; set; }
        public bool IsSelfDrive { get; set; }
        public DateTime? StartTime { get; set; }


        public virtual User UserDriver { get; set; }
        public virtual User User { get; set; }

        public virtual Location StartLocation { get; set; }
        public virtual Location EndLocation { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
