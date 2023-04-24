﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.DTOs.Rating
{
    public class RatingDto
    {
        public int UserId { get; set; }
        public int UserDriverId { get; set; }
        public int OrderId { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
