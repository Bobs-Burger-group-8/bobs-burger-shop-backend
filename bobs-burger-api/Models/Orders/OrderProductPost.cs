using bobs_burger_api.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bobs_burger_api.Models.Orders
{
    public class OrderProductPost
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
