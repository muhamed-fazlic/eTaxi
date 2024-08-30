using eTaxi.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.DTOs.FITPasos
{
    public class FITPasosSearchDto
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public bool? IsValid { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }

    }
}
