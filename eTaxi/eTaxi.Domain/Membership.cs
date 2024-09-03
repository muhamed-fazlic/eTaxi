using eTaxi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Domain
{
    public class Membership: BaseEntity
    {
        public int UserId { get; set; }
        public string Tier { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }

        public bool CalculateIsActive()
        {
            var today= DateTime.Now;
            return today>=StartTime && today<=EndTime;
        }
    }
}
