using bobs_burger_api.Models;
using bobs_burger_api.Repository;

namespace bobs_burger_api.Endpoints
{
    public static class UserEndpoint
    {
        public static void ConfigureUserEndpoint(this WebApplication app)
        {
            var products = app.MapGroup("users");

            products.MapGet("/{id}", GetUserById);
            products.MapPost("/{id}", AddUser);
            products.MapPut("/{id}", UpdateUser);
            products.MapDelete("/{id}", DeleteUser);
        }

        public static async Task<IResult> GetUserById(IRepository<User> repository, int id)
        {
            var user = await repository.Get(id);
            if (user == null)
            {
                return TypedResults.NotFound($"User with id {id} not found");
            }
            return TypedResults.Ok(user);
        }

        public static async Task<IResult> AddUser(IRepository<User> repository, UserPost newUser)
        {
            if(string.IsNullOrEmpty(newUser.FirstName))
            {
                return TypedResults.BadRequest("A first name is required");
            }
            if (string.IsNullOrEmpty(newUser.LastName))
            {
                return TypedResults.BadRequest("A last name is required");
            }
            if (string.IsNullOrEmpty(newUser.Email))
            {
                return TypedResults.BadRequest("A email is required");
            }
            if (string.IsNullOrEmpty(newUser.Phone))
            {
                return TypedResults.BadRequest("A phone number is required");
            }
            if (string.IsNullOrEmpty(newUser.Street))
            {
                return TypedResults.BadRequest("A street is required");
            }
            if (string.IsNullOrEmpty(newUser.City))
            {
                return TypedResults.BadRequest("A city is required");
            }

            User user = new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Phone = newUser.Phone,
                Street = newUser.Street,
                City = newUser.City
            };

            var addedUser = await repository.Add(user);
            return TypedResults.Created($"/{addedUser.Id}", addedUser);
        }

        public static async Task<IResult> UpdateUser(IRepository<User> repository, User changedUser)
        {
            var user = repository.Get(changedUser.Id);
            if (user == null)
            {
                return TypedResults.NotFound($"User with id {changedUser.Id} not found");
            }

            var updatedUser = await repository.Update(changedUser);
            return TypedResults.Created($"/{updatedUser.Id}", updatedUser);
        }

        public static async Task<IResult> DeleteUser(IRepository<User> repository, int id)
        {
            var deletedUser = await repository.Delete(id);
            if (deletedUser == null)
            {
                return TypedResults.NotFound($"User with id {id} not found");
            }
            return TypedResults.Ok(deletedUser);
        }
    }
}
