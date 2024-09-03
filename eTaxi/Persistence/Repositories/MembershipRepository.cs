using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Membership;
using eTaxi.Application.DTOs.Rating;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Persistence.Repositories
{
    
    public class MembershipRepository : GenericRepository<Membership, MembershipSearchDto>, IMembershipRepository
    {
        public MembershipRepository(TaxiDatabaseContext context) : base(context)
        {
        }

        public async override Task<IReadOnlyList<Membership>> GetAsync(MembershipSearchDto search = null)
        {
            var entity = _context.Membership.Include(x=>x.User).AsQueryable();

            if (search.UserId != null)
            {
                entity = entity.Where(x => x.UserId == search.UserId);
            }
           
            if (!search.Tier.IsNullOrEmpty())
            {
                entity = entity.Where(x => x.Tier.Contains(search.Tier));
            }
            if (search.StartTime != null)
            {
                entity = entity.Where(x => x.StartTime >= search.StartTime);
            }
            if (search.EndTime != null)
            {
                entity = entity.Where(x => x.EndTime <= search.EndTime);
            }

            return await entity.ToListAsync();

        }
    }
}
