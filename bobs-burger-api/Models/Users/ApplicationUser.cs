using bobs_burger_api.Models.Favourites;
using bobs_burger_api.Models.Orders;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bobs_burger_api.Models.Users
{
    [Table("app_users")]
    public class ApplicationUser : IdentityUser
    {
        public UserRole Role { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("street")]
        public string Street { get; set; }
        [Column("city")]
        public string City { get; set; }
        [JsonIgnore]
        public List<Favourite> Favourites { get; set; } = new List<Favourite>();
        [JsonIgnore]
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
