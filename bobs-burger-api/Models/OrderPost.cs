using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bobs_burger_api.Models
{
    public class OrderPost
    {
        public int UserId { get; set; }
        public List<int> ProductIds { get; set; }
        public double Total {  get; set; }
    }
}
