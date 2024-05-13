using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Order;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace eTaxi.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order, OrderSearchDto>, IOrderRepository
    {
        public OrderRepository(TaxiDatabaseContext context) : base(context)
        {
        }

        public override async Task<IReadOnlyList<Order>> GetAsync(OrderSearchDto search = null)
        {
            var orderList =  _context.Order.AsQueryable();

            if (search != null)
            {
                if (!string.IsNullOrEmpty( search.PaymentMethod))
                {
                    orderList= orderList.Where(order=>order.PaymentMethod.Contains(search.PaymentMethod));
                }
                if (search.IsActive != null)
                {
                    orderList=orderList.Where(order=>order.IsActive==search.IsActive);
                }
                if(search.IsSelfDrive != null)
                {
                    orderList = orderList.Where(order=>order.IsSelfDrive==search.IsSelfDrive);
                }
                if(search.UserId != null)
                {
                    orderList = orderList.Where(order => order.UserId == search.UserId);
                }
                if (search.UserDriverId != null)
                {
                    orderList = orderList.Where(order => order.UserDriverId == search.UserDriverId);
                }
                if(search.IsCanceled!= null)
                {
                    orderList=orderList.Where(order=>order.IsCanceled==search.IsCanceled);
                }
                if (search.CompanyId != null)
                {
                    orderList=orderList.Where(order=>order.Vehicle.CompanyId==search.CompanyId);
                }
                if(search.StartTime != null)
                {
                    orderList=orderList.Where(order=>order.StartTime>=search.StartTime);
                }
                if(search.EndTime != null)
                {
                    orderList = orderList.Where(order => order.EndTime == null || order.EndTime <= search.EndTime);
                }

                if (search.OrderBy == OrderBy.ASC)
                {
                    orderList = orderList.OrderBy(order => order.StartTime);
                }
                else
                {
                    orderList = orderList.OrderByDescending(order => order.StartTime);
                }

            }

            return await orderList.ToListAsync();
        }
    }
}
