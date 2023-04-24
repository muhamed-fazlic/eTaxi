using eTaxi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Domain
{
    public  class HubStation: BaseEntity
    {
     
        public string Name { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
