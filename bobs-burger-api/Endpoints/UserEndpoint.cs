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
            users.MapPut("/{id}", UpdateUser);
            users.MapDelete("/{id}", DeleteUser);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetUserById(IRepository<ApplicationUser> repository, string id)
        {
            var user = await repository.Get(id);
            if (user == null)
            {
                return TypedResults.NotFound($"User with id {id} not found");
            }
            UserResponse response = new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Street = user.Street,
                City = user.City,
            };
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateUser(IRepository<ApplicationUser> repository, string id, UserPost changedUser)
        {
            var user = await repository.Get(id);
            if (user == null)
            {
                return TypedResults.NotFound($"User with id {id} not found");
            }

            var users = await repository.GetAll();

            if (users.FirstOrDefault(u => u.Email == changedUser.Email && u.Id != user.Id) != null)
            {
                return TypedResults.BadRequest($"User with email {changedUser.Email} already exists!");
            }

            user.City = changedUser.City;
            user.Street = changedUser.Street;
            user.FirstName = changedUser.FirstName;
            user.LastName = changedUser.LastName;
            user.Email = changedUser.Email;
            user.NormalizedEmail = changedUser.Email.ToUpper();
            user.UserName = changedUser.Email;
            user.NormalizedUserName = changedUser.Email.ToUpper();
            user.PhoneNumber = changedUser.Phone;

            var updatedUser = await repository.Update(user);
            UserResponse response = new UserResponse
            {
                Id = updatedUser.Id,
                FirstName = updatedUser.FirstName,
                LastName = updatedUser.LastName,
                Email = updatedUser.Email,
                Phone = updatedUser.PhoneNumber,
                Street = updatedUser.Street,
                City = updatedUser.City,
            };
            return TypedResults.Created($"/{updatedUser.Id}", response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteUser(IRepository<ApplicationUser> repository, string id)
        {
            var deletedUser = await repository.Delete(id);
            if (deletedUser == null)
            {
                return TypedResults.NotFound($"User with id {id} not found");
            }
            UserResponse response = new UserResponse
            {
                Id = deletedUser.Id,
                FirstName = deletedUser.FirstName,
                LastName = deletedUser.LastName,
                Email = deletedUser.Email,
                Phone = deletedUser.PhoneNumber,
                Street = deletedUser.Street,
                City = deletedUser.City,
            };
            return TypedResults.Ok(response);
        }
    }
}
