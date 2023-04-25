using eTaxi.Application.Contracts.Persistence;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;

namespace eTaxi.Persistence.Repositories
{
    public class HubStationRepository : GenericRepository<HubStation, object>, IHubStationRepository

    {
        public HubStationRepository(TaxiDatabaseContext context) : base(context)
        {
        }
    }
}
