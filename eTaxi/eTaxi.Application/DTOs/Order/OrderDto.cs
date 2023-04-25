namespace eTaxi.Application.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int UserDriverId { get; set; }
        public int? UserId { get; set; }
        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }
        public int VehicleId { get; set; }
        public bool IsSelfDrive { get; set; }
        public DateTime? StartTime { get; set; }
    }
}
