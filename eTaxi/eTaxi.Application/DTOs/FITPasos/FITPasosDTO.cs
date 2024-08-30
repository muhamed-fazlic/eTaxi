using eTaxi.Application.DTOs.User;
using eTaxi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.DTOs.FITPasos
{
    public class FITPasosDto
    {
        public int Id { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public DateTime DatumVazenja { get; set; }
        public bool IsValid { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }

    }
}
