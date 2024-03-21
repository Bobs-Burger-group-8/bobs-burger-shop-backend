using bobs_burger_api.Models.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bobs_burger_api.Models.Orders
{
    [Table("order_product")]
    public class OrderProduct
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("order_id")]
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
    }
}
