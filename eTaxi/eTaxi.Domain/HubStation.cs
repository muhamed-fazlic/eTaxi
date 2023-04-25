using eTaxi.Domain.Common;

namespace eTaxi.Domain
{
    public class HubStation : BaseEntity
    {

        public string Name { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
