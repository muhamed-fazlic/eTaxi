using eTaxi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Domain
{
    public  class MaliciousUser:BaseEntity
    {
        public MaliciousUser()
        {
            DateCreated = DateTime.Now;

        }
        public int UserId { get; set; }
        public bool IsSuspicious { get; set; }

        public virtual User User { get; set; }
    }
}
