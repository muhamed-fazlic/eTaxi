using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Rating;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace eTaxi.Persistence.Repositories
{
    public class RatingRepository : GenericRepository<Rating, RatingSearchDto>, IRatingRepository
    {
        public RatingRepository(TaxiDatabaseContext context) : base(context)
        {
        }

        public async override Task<IReadOnlyList<Rating>> GetAsync(RatingSearchDto search = null)
        {
            var entity = _context.Rating.AsQueryable();

            if (search.UserId != null)
            {
                entity = entity.Where(rating => rating.UserId == search.UserId);
            }
            if (search.UserDriverId != null)
            {
                entity = entity.Where(rating => rating.UserDriverId == search.UserDriverId);
            }
            if (search.Grade != null)
            {
                entity = entity.Where(rating => rating.Grade == search.Grade);
            }

            return await entity.ToListAsync();

        }
    }
}
