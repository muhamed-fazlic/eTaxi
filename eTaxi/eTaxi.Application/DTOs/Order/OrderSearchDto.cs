

using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace eTaxi.Application.DTOs.Order
{
    public class OrderSearchDto
    {
        public bool? IsActive { get; set; }
        public int? UserDriverId { get; set; }
        public int? UserId { get; set; }
        public bool? IsSelfDrive { get; set; }
        public string PaymentMethod { get; set; }
        public bool? IsCanceled { get; set; }
        public int? CompanyId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string OrderBy { get; set; }

    }

    public class OrderBy
    {
        public const string ASC = "ASC";
        public const string DESC = "DESC";

    }

}
