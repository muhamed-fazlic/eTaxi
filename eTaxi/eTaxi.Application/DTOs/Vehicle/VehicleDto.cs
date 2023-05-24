namespace eTaxi.Application.DTOs.Vehicle
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double KmTraveled { get; set; }
        public string LicenceNumber { get; set; }
        public int Year { get; set; }
        public bool AirCondition { get; set; }
        public bool AirBag { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public int CurrentLocationId { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public int PricePerKm { get; set; }
        public int? UserDriverId { get; set; }
        public string ImageUrl { get; set; }
        public Domain.VehicleType Type { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set;}


    }
}
