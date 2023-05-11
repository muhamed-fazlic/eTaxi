using eTaxi.Application.DTOs.Location;
using eTaxi.Application.DTOs.User;
using eTaxi.Application.DTOs.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.DTOs.Order
{
    public  class OrderSearchDto
    {
        public bool? IsActive { get; set; }
        public int? UserDriverId { get; set; }
        public int? UserId { get; set; }
        public bool? IsSelfDrive { get; set; }
        public string PaymentMethod { get; set; }
        public bool? IsCanceled { get; set; }

    }
}
