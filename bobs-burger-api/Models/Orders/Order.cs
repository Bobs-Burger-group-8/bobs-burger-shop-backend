using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using bobs_burger_api.Models.Users;

namespace bobs_burger_api.Models.Orders
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public string UserId { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }
        [Column("products")]
        public List<int> ProductIds { get; set; }
        [Column("total")]
        public double Total { get; set; }
        [Column("order_time")]
        public DateTime DateTime { get; set; }
        [Column("completed")]
        public bool Completed { get; set; }
    }
}
