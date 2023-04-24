using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Favorite;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Persistence.Repositories
{
    public  class FavoriteRepository: GenericRepository<Favorite, object>, IFavoriteRepository

    {
        public FavoriteRepository(TaxiDatabaseContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Favorite>> GetAsync(int? userId)
        {
            var userFavoritesList=await _context.Favorite.Where(f => f.UserId == userId).ToListAsync();
            return userFavoritesList;
        }

    }
}
