using eTaxi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Domain
{
    public class FITPasos: BaseEntity
    {
        public DateTime DatumIzdavanja { get; set; }
        public DateTime DatumVazenja { get; set; }
        public bool IsValid { get; set; }
        public int UserId { get; set; }


        public virtual User User { get; set; }
    }
}
