using eTaxi.Application.DTOs.Location;
using eTaxi.Application.DTOs.User;


namespace eTaxi.Application.DTOs.Reports
{
    public class ReportDto
    {

        //najvise koristena ruta taxija, kojim danom i u koje vrijeme imaju najvise narudzbi,
        public int TotalOrders { get; set; }
        public double TotalEarnedMoney { get; set; }
        public int TotalCanceledOrders { get; set; }
        public UserDto UserWithMostOrders { get; set; }
        public UserDto DriverWithMostOrders { get; set; }
        public List<UserOrderCount> UserOrderCount { get; set; }
        public List<VehicleOrderCount> VehicleOrderCount { get; set; }
        public dynamic MostFrequentTime { get; set; }
        public dynamic MostFrequentRoute { get; set; }

    }
}
