using eTaxi.Application.DTOs.Favorite;
using eTaxi.Application.DTOs.File;
using Microsoft.AspNetCore.Identity;

namespace eTaxi.Application.DTOs.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int? Pin { get; set; }
        public int? CompanyId { get; set; }
        public ICollection<FileDto> Files { get; set; }
        public ICollection<FavoriteDto> Favorites { get; set; }
        public dynamic RatingGrade { get; set; }
        public string UserType { get; set; }
    }
}
