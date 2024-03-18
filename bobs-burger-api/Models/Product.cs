using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bobs_burger_api.Models
{
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
    }
}
