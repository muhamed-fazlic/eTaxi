using eTaxi.Application.Contracts.Persistence;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;

namespace eTaxi.Persistence.Repositories
{
    public class FileRepository : GenericRepository<Domain.File, object>, IFileRepository
    {
        public FileRepository(TaxiDatabaseContext context) : base(context)
        {
        }
    }
}
