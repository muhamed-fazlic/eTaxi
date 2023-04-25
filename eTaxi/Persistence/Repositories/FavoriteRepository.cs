using eTaxi.Application.Contracts.Persistence;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace eTaxi.Persistence.Repositories
{
    public class FavoriteRepository : GenericRepository<Favorite, object>, IFavoriteRepository

    {
        public FavoriteRepository(TaxiDatabaseContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Favorite>> GetAsync(int? userId)
        {
            var userFavoritesList = await _context.Favorite.Where(f => f.UserId == userId).ToListAsync();
            return userFavoritesList;
        }

    }
}
