using Microsoft.AspNetCore.Identity;

namespace eTaxi.Domain
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
