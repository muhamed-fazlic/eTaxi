using eTaxi.Application.DTOs.Rating;
using eTaxi.Domain;

namespace eTaxi.Application.Contracts.Persistence
{
    public interface IRatingRepository : IGenericRepository<Rating, RatingSearchDto>
    {
    }
}
