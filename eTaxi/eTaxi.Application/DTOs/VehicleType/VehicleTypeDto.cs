using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.DTOs.VehicleType
{
    public partial class VehicleTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int NumberOfSeats { get; set; }
        public string ImageUrl { get; set; }

        // public int FileId { get; set; }
        //public virtual File File { get; set; }
    }
}
