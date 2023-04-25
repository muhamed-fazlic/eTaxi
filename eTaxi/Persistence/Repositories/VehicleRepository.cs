using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Vehicle;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace eTaxi.Persistence.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle, VehicleSearchDto>, IVehicleRepository
    {
        public VehicleRepository(TaxiDatabaseContext context) : base(context)
        {
        }

        public async override Task<IReadOnlyList<Vehicle>> GetAsync(VehicleSearchDto search = null)
        {
            var vehicles = _context.Vehicle.AsQueryable();
            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Type))
                {
                    vehicles = vehicles.Where(v => v.Type.Type == search.Type);
                }
                if (search.NumberOfSeats != null)
                {
                    vehicles = vehicles.Where(v => v.Type.NumberOfSeats == search.NumberOfSeats);
                }
                if (!string.IsNullOrEmpty(search.Brand))
                {
                    vehicles = vehicles.Where(v => v.Brand.Contains(search.Brand));
                }
                if (!string.IsNullOrEmpty(search.FuelType))
                {
                    vehicles = vehicles.Where(v => v.FuelType.Contains(search.FuelType));
                }
            }
            return await vehicles.ToListAsync();
        }
    }

}
