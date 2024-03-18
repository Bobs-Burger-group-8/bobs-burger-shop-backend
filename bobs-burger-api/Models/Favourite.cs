using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bobs_burger_api.Models
{
    [Table("favourites")]
    public class Favourite
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}
