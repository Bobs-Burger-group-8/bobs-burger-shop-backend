using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bobs_burger_api.Models.Ingredients
{
    [Table("ingredients")]
    public class Ingredient
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("category")]
        public string Category { get; set; }
        [Column("price")]
        public double Price { get; set; }
    }
}
