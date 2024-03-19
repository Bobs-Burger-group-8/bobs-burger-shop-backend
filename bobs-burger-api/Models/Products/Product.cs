using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using bobs_burger_api.Models.Favourites;

namespace bobs_burger_api.Models.Products
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("category")]
        public string Category { get; set; }
        [Column("price")]
        public double Price { get; set; }
        [Column("ingredients")]
        public List<int> Ingredients { get; set; } = new List<int>();
        [Column("image")]
        public string Image { get; set; }
        [JsonIgnore]
        public List<Favourite> Favourites { get; set; }
    }
}
