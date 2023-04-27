using eTaxi.Application.Contracts.Persistence;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;

namespace eTaxi.Persistence.Repositories
{
    public class FeedbackRepository : GenericRepository<Feedback, object>, IFeedbackRepository
    {
        public FeedbackRepository(TaxiDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
