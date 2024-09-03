using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Order;
using eTaxi.Application.DTOs.Subscription;
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
   
    public class SubscriptionRepository : GenericRepository<Subscription, SubscriptionSearchDto>, ISubscriptionRepository
    {
        public SubscriptionRepository(TaxiDatabaseContext context) : base(context)
        {
        }

        public override async Task<IReadOnlyList<Subscription>> GetAsync(SubscriptionSearchDto search = null)
        {
            var subsList = _context.Subscription.Include(s=>s.User).AsQueryable();

            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.SubscriptionType))
                {
                    subsList = subsList.Where(x => x.SubscriptionType.Contains(search.SubscriptionType));
                }
                if (search.IsActive != null)
                {
                    subsList = subsList.Where(x => x.IsActive == search.IsActive);
                }
            
                if (search.UserId != null)
                {
                    subsList = subsList.Where(x => x.UserId == search.UserId);
                }
            
              
              
                if (search.From != null)
                {
                    subsList = subsList.Where(x => x.StartTime >= search.From);
                }
                if (search.To != null)
                {
                    subsList = subsList.Where(x =>  x.EndTime <= search.To);
                }

             
              

            }

            return await subsList.ToListAsync();
        }
    }
}
