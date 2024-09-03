using eTaxi.Application.DTOs.Order;
using eTaxi.Application.DTOs.Subscription;
using eTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Contracts.Persistence
{
    
    public interface ISubscriptionRepository : IGenericRepository<Subscription, SubscriptionSearchDto>
    {
    }
}
