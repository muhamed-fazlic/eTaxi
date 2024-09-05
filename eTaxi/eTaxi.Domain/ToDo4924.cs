using eTaxi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Domain
{
    public class ToDo4924:BaseEntity
    {
        public int UserId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime KrajnjiRok { get; set; }
        public string Status { get; set; }
        public virtual User User { get; set; }
    }
}
