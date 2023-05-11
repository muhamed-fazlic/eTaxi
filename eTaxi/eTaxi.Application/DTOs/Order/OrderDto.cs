using eTaxi.Application.DTOs.Location;
using eTaxi.Application.DTOs.User;
using eTaxi.Application.DTOs.Vehicle;

namespace eTaxi.Application.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int UserDriverId { get; set; }
        public int? UserId { get; set; }
        public double Price { get; set; }
        public bool IsSelfDrive { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string PaymentMethod { get; set; }
        public bool? IsCanceled { get; set; }
        public string CancelReason { get; set; }
        public LocationDto StartLocation { get; set; }
        public LocationDto EndLocation { get; set; }
        public VehicleDto Vehicle { get; set; }
        public UserDto User { get; set; }
    }
}
