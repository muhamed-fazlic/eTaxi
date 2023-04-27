using eTaxi.Application.DTOs.File;

namespace eTaxi.Application.DTOs.Feedback
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public int OrderId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int Grade { get; set; }
        public ICollection<FileDto> Files { get; set; }
    }
}
