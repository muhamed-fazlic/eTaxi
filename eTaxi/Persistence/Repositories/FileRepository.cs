using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.File;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace eTaxi.Persistence.Repositories
{
    public class FileRepository : GenericRepository<Domain.File, FileSearchDto>, IFileRepository
    {
        public FileRepository(TaxiDatabaseContext context) : base(context)
        {
        }

        public override async Task<IReadOnlyList<Domain.File>> GetAsync(FileSearchDto search)
        {
            var files = _context.File.AsQueryable();
            if (search.FeedbackId != null)
            {
                files = files.Where(x => x.FeedbackId == search.FeedbackId);
            }
            if (search.UserId != null)
            {
                files = files.Where(x => x.UserId == search.UserId);
            }
            if (!string.IsNullOrEmpty(search.Type))
            {
                files = files.Where(x => x.Type.Contains(search.Type));
            }

            return await files.ToListAsync();
        }
    }
}
