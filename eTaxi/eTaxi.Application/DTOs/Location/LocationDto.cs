using eTaxi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.DTOs.Location
{
    public class LocationDto 
    {
        public string StreetNumber { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Address { get; set; }

    }
}
