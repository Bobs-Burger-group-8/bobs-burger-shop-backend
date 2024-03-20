using bobs_burger_api.Models.Users;

namespace bobs_burger_api.Models
{
    public class DTO
    {
        public record RegisterDto(string Email, string Password, string FirstName, string LastName, string Street, string City, string Phone, UserRole Role);
        public record RegisterResponseDto(string Email, UserRole Role);
        public record LoginDto(string Email, string Password);
        public record AuthResponseDto(string Token, string Email, string Id, UserRole Role);

    }
}
