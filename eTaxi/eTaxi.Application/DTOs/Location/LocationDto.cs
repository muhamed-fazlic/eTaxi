namespace eTaxi.Application.DTOs.Location
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string StreetNumber { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public double? Latitude { get; set; } 
        public double? Longitude { get; set; } 
        public string Address { get; set; }

    }
}
