using eTaxi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Domain
{
    public class Subscription:BaseEntity
    {
        public int UserId { get; set; }
        public string SubscriptionType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }

        public virtual User User { get; set; }

        public Subscription() { }

        public Subscription(DateTime start, DateTime end)
        {
            StartTime = start;
            EndTime = end;
            IsActive = CalculateIsActive();
        }

        public bool CalculateIsActive()
        {
            var today=DateTime.Now;
            return today>=StartTime && today<=EndTime;
        }
    }
}
