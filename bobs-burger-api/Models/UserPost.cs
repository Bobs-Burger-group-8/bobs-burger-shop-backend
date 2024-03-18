using System.ComponentModel.DataAnnotations.Schema;

namespace bobs_burger_api.Models
{
    public class UserPost
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}
