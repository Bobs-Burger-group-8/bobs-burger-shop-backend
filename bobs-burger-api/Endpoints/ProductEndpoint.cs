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
        }

        public static async Task<IResult> GetAllProducts(IRepository<Product> repository)
        {
            return TypedResults.Ok(await repository.GetAll());
        }
    }
}
