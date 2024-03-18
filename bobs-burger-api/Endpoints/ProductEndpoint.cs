using bobs_burger_api.Models;
using bobs_burger_api.Repository;

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

        public static async Task<IResult> GetAllProducts(IRepository<Product> repository)
        {
            return TypedResults.Ok(await repository.GetAll());
        }

        public static async Task<IResult> GetProductById(IRepository<Product> repository, int id)
        {
            var product = await repository.Get(id);
            if (product == null)
            {
                return TypedResults.NotFound($"Product with id {id} not found");
            }
            return TypedResults.Ok(product);
        }

        public static async Task<IResult> GetProductsByCategory(IRepository<Product> repository, string category)
        {
            Console.WriteLine(category);
            if (string.IsNullOrEmpty(category))
            {
                return TypedResults.BadRequest("Category must be provided");
            }
            if (category != "burger" && category != "drink")
            {
                return TypedResults.BadRequest("Category must be either burger or drink");
            }
            var products = await repository.GetAll();
            products = products.Where(product => product.Category == category).ToList();
            return TypedResults.Ok(products);
        }

        public static async Task<IResult> GetIngredientsByProductId(IRepository<Product> repository, int id)
        {
            var product = await repository.Get(id);
            if (product == null)
            {
                return TypedResults.NotFound($"Product with id {id} not found");
            }
            return TypedResults.Ok(product.Ingredients);
        }
    }
}
