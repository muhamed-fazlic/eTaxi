using eTaxi.Application.DTOs.File;

namespace eTaxi.Application.DTOs.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int? Pin { get; set; }
        public ICollection<FileDto> Files { get; set; }
    }
}
