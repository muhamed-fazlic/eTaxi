using eTaxi.Application.Contracts.Persistence;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;

namespace eTaxi.Persistence.Repositories
{
    public class CompanyRepository : GenericRepository<Company, object>, ICompanyRepository
    {
        public CompanyRepository(TaxiDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
