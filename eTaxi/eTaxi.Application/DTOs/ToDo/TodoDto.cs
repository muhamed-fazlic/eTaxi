using eTaxi.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.DTOs.ToDo
{
    public class TodoDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime KrajnjiRok { get; set; }
        public string Status { get; set; }
        public  UserDto User { get; set; }
    }
}
