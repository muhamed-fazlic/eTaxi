using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.MaliciousUser;
using eTaxi.Application.DTOs.Rating;
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
   

    public class MaliciousUserRepository : GenericRepository<MaliciousUser, MaliciousUserSearchDto>, IMaliciousUserRepository
    {
        public MaliciousUserRepository(TaxiDatabaseContext context) : base(context)
        {
        }

        public async override Task<IReadOnlyList<MaliciousUser>> GetAsync(MaliciousUserSearchDto search = null)
        {
            var entity = _context.MaliciousUser.Include(x=>x.User).AsQueryable();

            if (search.UserId != null)
            {
                entity = entity.Where(x => x.UserId == search.UserId);
            }
            if (search.IsSuspicious != null)
            {
                entity = entity.Where(x => x.IsSuspicious == search.IsSuspicious);
            }
            if (search.From != null)
            {
                entity = entity.Where(x => search.From <=x.DateCreated);
            }
            if (search.To != null)
            {
                entity = entity.Where(x =>  search.To >=x.DateCreated);
            }

            return await entity.ToListAsync();

        }
    }
}
