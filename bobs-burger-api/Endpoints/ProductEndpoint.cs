using bobs_burger_api.Models.Ingredients;
using bobs_burger_api.Models.Products;
using bobs_burger_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace bobs_burger_api.Endpoints
{
    public static class ProductEndpoint
    {
        public static void ConfigureProductEndpoint(this WebApplication app)
        {
            var products = app.MapGroup("products");

            products.MapGet("", GetAllProducts);
            products.MapGet("/{id}", GetProductById);
            products.MapGet("/category={category}", GetProductsByCategory);
            products.MapGet("/{id}/ingredients", GetIngredientsByProductId);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllProducts(IRepository<Product> repository)
        {
            return TypedResults.Ok(await repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetProductById(IRepository<Product> repository, int id)
        {
            var product = await repository.Get(id);
            if (product == null)
            {
                return TypedResults.NotFound($"Product with id {id} not found");
            }
            return TypedResults.Ok(product);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetProductsByCategory(IRepository<Product> repository, string category)
        {
            Console.WriteLine(category);
            if (string.IsNullOrEmpty(category))
            {
                return TypedResults.BadRequest("Category must be provided");
            }
            if (category != "burger" && category != "drink" && category != "sides")
            {
                return TypedResults.BadRequest("Category must be either burger or drink");
            }
            var products = await repository.GetAll();
            products = products.Where(product => product.Category == category).ToList();
            return TypedResults.Ok(products);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetIngredientsByProductId(IRepository<Product> productRepository, IRepository<Ingredient> ingredientRepository, int id)
        {
            var product = await productRepository.Get(id);
            if (product == null)
            {
                return TypedResults.NotFound($"Product with id {id} not found");
            }

            var ingredients = await ingredientRepository.GetAll();
            var result = ingredients.Where(ingredient => product.Ingredients.Contains(ingredient.Id));

            return TypedResults.Ok(result);
        }
    }
}
