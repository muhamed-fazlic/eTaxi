using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.DTOs.Reports
{
    public class VehicleOrderCount
    {
        public string VehicleName { get; set; }
        public int VehicleId { get; set; }
        public int OrderCount { get; set; }
    }
}
