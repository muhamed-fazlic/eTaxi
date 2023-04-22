using eTaxi.Application.Contracts.Persistence;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;


namespace eTaxi.Persistence.Repositories
{
    public class VehicleTypeRepository : GenericRepository<VehicleType, string>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(TaxiDatabaseContext context) : base(context)
        {
        }
    }
}
