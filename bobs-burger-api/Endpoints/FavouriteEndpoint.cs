using bobs_burger_api.Models;
using bobs_burger_api.Models.Favourites;
using bobs_burger_api.Models.Products;
using bobs_burger_api.Models.Users;
using bobs_burger_api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bobs_burger_api.Endpoints
{
    public static class FavouriteEndpoint
    {
        public static void ConfigureFavouriteEndpoint(this WebApplication app)
        {
            var favourites = app.MapGroup("favourites");

            favourites.MapGet("", GetAll);
            favourites.MapGet("/user/{userId}", GetByUserId);
            favourites.MapPost("", AddFavourite);
            favourites.MapDelete("/{id}", DeleteFavourite);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Favourite> repository)
        {
            return TypedResults.Ok(await repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetByUserId(IRepository<Favourite> favouriteRepository, IRepository<ApplicationUser> userRepository, string userId)
        {
            var user = await userRepository.Get(userId);
            if (user == null)
            {
                return TypedResults.NotFound($"User with id {userId} not found");
            }
            var favourites = await favouriteRepository.GetAll();
            return TypedResults.Ok(favourites.Where(fave => fave.UserId.Equals(userId)).ToList());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddFavourite
            (
                IRepository<Favourite> favouriteRepository, 
                IRepository<ApplicationUser> userRepository, 
                IRepository<Product> productRepository, 
                FavouritePost newFavourite
            )
        {
          /*  if (userRepository.Get(newFavourite.UserId) == null)
            {
                return TypedResults.NotFound($"User with id {newFavourite.UserId} was not found");
            }
            if (productRepository.Get(newFavourite.ProductId) == null)
            {
                return TypedResults.NotFound($"Product with id {newFavourite.ProductId} was not found");
            }
          */
            var favourite = new Favourite
            {
                UserId = newFavourite.UserId,
                ProductId = newFavourite.ProductId,
            };

            var addedFavourite = await favouriteRepository.Add(favourite);
            return TypedResults.Created($"{addedFavourite.Id}", addedFavourite);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteFavourite(IRepository<Favourite> repository, int id)
        {
            var deletedFavourite = await repository.Delete(id);
            if (deletedFavourite == null)
            {
                return TypedResults.NotFound($"Favourite with id {id} was not found");
            }
            return TypedResults.Ok(deletedFavourite);
        }
    }
}
