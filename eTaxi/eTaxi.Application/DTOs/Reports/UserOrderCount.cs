using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.DTOs.Reports
{
    public class UserOrderCount
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public int OrderCount { get; set; }
    }
}
