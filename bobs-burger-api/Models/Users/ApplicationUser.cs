using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace bobs_burger_api.Models.Users
{
    public class ApplicationUser : IdentityUser
    {
        public UserRole Role { get; set; }
    }
}
