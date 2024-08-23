using eTaxi.Domain.Common;

namespace eTaxi.Domain
{
    public class Vehicle : BaseEntity
    {
        public Vehicle()
        {
            DateCreated = DateTime.Now;
        }
        public string Name { get; set; }
        public double KmTraveled { get; set; }
        public string LicenceNumber { get; set; }
        public int Year { get; set; }
        public bool AirCondition { get; set; }
        public bool AirBag { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public int? CurrentLocationId { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public double PricePerKm { get; set; }
        public int? UserDriverId { get; set; }
        public int TypeId { get; set; }
        public string ImageUrl { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual VehicleType Type { get; set; }
        public virtual Location CurrentLocation { get; set; }
        public virtual User UserDriver { get; set; }
    }
}
