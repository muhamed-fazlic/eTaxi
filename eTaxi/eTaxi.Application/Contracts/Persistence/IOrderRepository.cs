using eTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Contracts.Persistence
{
    public  interface IOrderRepository: IGenericRepository<Order, object>
    {
    }
}
