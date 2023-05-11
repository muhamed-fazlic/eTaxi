using eTaxi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Domain
{
    public class Company: BaseEntity
    {
        public Company()
        {
            Vehicles = new HashSet<Vehicle>();
            Drivers = new HashSet<User>();
            DateCreated = DateTime.Now;
        }
        public string Name { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<User> Drivers { get; set; }
    }
}
