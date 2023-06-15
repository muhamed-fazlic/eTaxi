using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.DTOs.Order
{
    public class OrderStatusDto
    {
        public int OrderId { get; set; }  
        public bool? IsActive { get; set; }
        public bool? IsCanceled { get; set; }
        public string CancelReason { get; set; } =string.Empty;
    }
}
