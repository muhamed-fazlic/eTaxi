﻿using eTaxi.Application.Contracts.Persistence;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;

namespace eTaxi.Persistence.Repositories
{
    public class LocationRepository : GenericRepository<Location, object>, ILocationRepository
    {
        public LocationRepository(TaxiDatabaseContext context) : base(context)
        {
        }
    }

}
