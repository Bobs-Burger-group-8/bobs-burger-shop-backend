using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using bobs_burger_api.Models.Favourites;
using bobs_burger_api.Models.Orders;

namespace bobs_burger_api.Models.Users
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("phone")]
        public string Phone {  get; set; }
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
