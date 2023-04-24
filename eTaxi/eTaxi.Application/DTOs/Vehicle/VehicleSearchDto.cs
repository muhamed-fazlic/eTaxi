using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.DTOs.Vehicle
{
    public  class VehicleSearchDto
    {
        public string Type { get; set; }
        public int? NumberOfSeats { get; set; }
        public string Brand { get; set; }
        public string FuelType { get; set; }
    }
}
