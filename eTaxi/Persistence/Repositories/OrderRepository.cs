using eTaxi.Application.Contracts.Persistence;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;

namespace eTaxi.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order, object>, IOrderRepository
    {
        public OrderRepository(TaxiDatabaseContext context) : base(context)
        {
        }
    }
}
