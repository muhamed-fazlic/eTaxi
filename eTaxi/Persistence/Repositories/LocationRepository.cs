using eTaxi.Application.Contracts.Persistence;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Persistence.Repositories
{
    public  class LocationRepository: GenericRepository<Location, object>, ILocationRepository
    {
        public LocationRepository(TaxiDatabaseContext context) : base(context)
        {
        }
    }

}
