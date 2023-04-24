using eTaxi.Application.Contracts.Persistence;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Persistence.Repositories
{
    public class OrderRepository: GenericRepository<Order, object>, IOrderRepository
    {
        public OrderRepository(TaxiDatabaseContext context) : base(context)
        {
        }
    }
}
