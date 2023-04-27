namespace eTaxi.Application.DTOs.File
{
    public class FileDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public string OriginalName { get; set; }
        public string Type { get; set; } = string.Empty;
        public int? FeedbackId { get; set; }
    }
}
