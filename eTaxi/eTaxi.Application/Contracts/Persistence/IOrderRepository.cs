using eTaxi.Application.DTOs.Order;
using eTaxi.Domain;

namespace eTaxi.Application.Contracts.Persistence
{
    public interface IOrderRepository : IGenericRepository<Order, OrderSearchDto>
    {
    }
}
