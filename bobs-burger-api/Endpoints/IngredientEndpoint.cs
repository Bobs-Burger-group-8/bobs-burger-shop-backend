using bobs_burger_api.Models;
using bobs_burger_api.Repository;
using Microsoft.AspNetCore.Mvc;

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

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllIngredients(IRepository<Ingredient> repository)
        {
            return TypedResults.Ok(await repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetIngredientById(IRepository<Ingredient> repository, int id)
        {
            var ingredient = await repository.Get(id);
            if (ingredient == null)
            {
                return TypedResults.NotFound($"Ingredient with id {id} not found");
            }
            return TypedResults.Ok(ingredient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
