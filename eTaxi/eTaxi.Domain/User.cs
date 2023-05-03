using Microsoft.AspNetCore.Identity;

namespace eTaxi.Domain
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            Files = new HashSet<File>();
        }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? Pin { get; set; }
        public ICollection<File> Files { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
