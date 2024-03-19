using bobs_burger_api.Models.Users;
using bobs_burger_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace bobs_burger_api.Endpoints
{
    public static class UserEndpoint
    {
        public static void ConfigureUserEndpoint(this WebApplication app)
        {
            var users = app.MapGroup("users");

            users.MapGet("/{id}", GetUserById);
            users.MapPost("", AddUser);
            users.MapPut("/{id}", UpdateUser);
            users.MapDelete("/{id}", DeleteUser);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetUserById(IRepository<User> repository, int id)
        {
            var user = await repository.Get(id);
            if (user == null)
            {
                return TypedResults.NotFound($"User with id {id} not found");
            }
            return TypedResults.Ok(user);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

            var users = await repository.GetAll();
            if (users.FirstOrDefault(user => user.Email == newUser.Email) != null)
            {
                return TypedResults.BadRequest($"User with email {newUser.Email} already exists");
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

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateUser(IRepository<User> repository, int id, User changedUser)
        {
            var user = await repository.Get(changedUser.Id);
            if (user == null)
            {
                return TypedResults.NotFound($"User with id {changedUser.Id} not found");
            }

            var users = await repository.GetAll();
            if (users.FirstOrDefault(user => user.Email == changedUser.Email) != null)
            {
                return TypedResults.BadRequest($"User with email {changedUser.Email} already exists");
            }

            var updatedUser = await repository.Update(changedUser);
            return TypedResults.Created($"/{updatedUser.Id}", updatedUser);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
