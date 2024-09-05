using eTaxi.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.DTOs.ToDo
{
    public class ToDoSearchDto
    {
        public int? UserId { get; set; }
        public DateTime? DatumVazenja { get; set; }
        public string Status { get; set; }
    }
}
