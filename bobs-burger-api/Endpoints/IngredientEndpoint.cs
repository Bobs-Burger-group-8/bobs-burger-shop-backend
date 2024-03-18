using bobs_burger_api.Models;
using bobs_burger_api.Repository;

namespace bobs_burger_api.Endpoints
{
    public static class IngredientEndpoint
    {
        public static void ConfigureIngredientEndpoint(this WebApplication app)
        {
            var ingredients = app.MapGroup("ingredients");

            ingredients.MapGet("", GetAllIngredients);
            ingredients.MapGet("/{id}", GetIngredientById);
            ingredients.MapGet("/{category}", GetIngredientsByCategory);
        }

        public static async Task<IResult> GetAllIngredients(IRepository<Ingredient> repository)
        {
            return TypedResults.Ok(await repository.GetAll());
        }

        public static async Task<IResult> GetIngredientById(IRepository<Ingredient> repository, int id)
        {
            var ingredient = await repository.Get(id);
            if (ingredient == null)
            {
                return TypedResults.NotFound($"Ingredient with id {id} not found");
            }
            return TypedResults.Ok(ingredient);
        }

        public static async Task<IResult> GetIngredientsByCategory(IRepository<Ingredient> repository, string category)
        {
            if (category != "burger")
            {
                return TypedResults.BadRequest($"Category must be burger");
            }

            var ingredients = await repository.GetAll();
            return TypedResults.Ok(ingredients.Where(ingredient => ingredient.Category == category));
        }
    }
}
