using bobs_burger_api.Models;
using bobs_burger_api.Repository;

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

        public static async Task<IResult> GetAll(IRepository<Favourite> repository)
        {
            return TypedResults.Ok(await repository.GetAll());
        }

        public static async Task<IResult> GetByUserId(IRepository<Favourite> favouriteRepository, IRepository<User> userRepository, int userId)
        {
            var user = await userRepository.Get(userId);
            if (user == null)
            {
                return TypedResults.NotFound($"User with id {userId} not found");
            }
            var favourites = await favouriteRepository.GetAll();
            return TypedResults.Ok(favourites.Where(fave => fave.UserId == userId).ToList());
        }

        public static async Task<IResult> AddFavourite
            (
            IRepository<Favourite> favouriteRepository, 
            IRepository<User> userRepository, 
            IRepository<Product> productRepository, 
            FavouritePost newFavourite
            )
        {
            if (userRepository.Get(newFavourite.UserId) == null)
            {
                return TypedResults.NotFound($"User with id {newFavourite.UserId} was not found");
            }
            if (productRepository.Get(newFavourite.ProductId) == null)
            {
                return TypedResults.NotFound($"Product with id {newFavourite.ProductId} was not found");
            }

            var favourite = new Favourite
            {
                UserId = newFavourite.UserId,
                ProductId = newFavourite.ProductId,
            };

            var addedFavourite = await favouriteRepository.Add(favourite);
            return TypedResults.Created($"{addedFavourite.Id}", addedFavourite);
        }

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
