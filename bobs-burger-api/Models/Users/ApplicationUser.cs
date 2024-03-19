using Microsoft.AspNetCore.Identity;

namespace bobs_burger_api.Models.Users
{
    public class ApplicationUser : IdentityUser
    {
        public UserRole Role { get; set; }
    }
}
