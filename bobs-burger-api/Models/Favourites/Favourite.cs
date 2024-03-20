using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using bobs_burger_api.Models.Users;
using bobs_burger_api.Models.Products;

namespace bobs_burger_api.Models.Favourites
{
    [Table("favourites")]
    public class Favourite
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public string UserId { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}
