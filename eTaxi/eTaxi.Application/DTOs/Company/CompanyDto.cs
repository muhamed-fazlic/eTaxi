using eTaxi.Application.DTOs.Vehicle;

namespace eTaxi.Application.DTOs.Company
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<VehicleDto> Vehicles { get; set; }
    }
}
