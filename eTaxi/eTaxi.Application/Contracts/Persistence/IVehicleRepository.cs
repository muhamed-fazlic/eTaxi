using eTaxi.Application.DTOs.Vehicle;
using eTaxi.Domain;

namespace eTaxi.Application.Contracts.Persistence
{
    public interface IVehicleRepository : IGenericRepository<Vehicle, VehicleSearchDto>
    {
    }
}
