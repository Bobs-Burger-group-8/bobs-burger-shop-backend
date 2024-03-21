using bobs_burger_api.Models.Orders;
using bobs_burger_api.Models.Products;
using bobs_burger_api.Models.Users;
using bobs_burger_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace bobs_burger_api.Endpoints
{
    public static class OrderEndpoint
    {
        public static void ConfigureOrderEndpoint(this WebApplication app)
        {
            var orders = app.MapGroup("orders");

            orders.MapGet("", GetAllOrders);
            orders.MapPost("", AddOrder);
            orders.MapPut("/{id}", UpdateOrder);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllOrders(IRepository<Order> repository)
        {
            return TypedResults.Ok(await repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddOrder(IRepository<Order> orderRepository, IRepository<ApplicationUser> userRepository, IRepository<Product> productRepository, OrderPost order)
        {
            List<OrderProduct> products = new List<OrderProduct>();
            foreach (var product in order.Products)
            {
                OrderProduct orderProduct = new OrderProduct
                {
                    ProductId = product.ProductId,
                    Quantity = product.Quantity,
                };
                products.Add(orderProduct);

            }
            Order newOrder = new Order
            {
                UserId = order.UserId,
                Products = products,
                Total = order.Total,
                DateTime = DateTime.UtcNow,
                Completed = false
            };

            var addedOrder = await orderRepository.Add(newOrder);
            return TypedResults.Created($"{addedOrder.Id}", addedOrder);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateOrder(IRepository<Order> repository, int id, bool completed)
        {
            var order = await repository.Get(id);
            if (order == null)
            {
                return TypedResults.NotFound($"Order with id {id} not found");
            }
            order.Completed = completed;
            var updatedOrder = await repository.Update(order);
            return TypedResults.Created($"{updatedOrder.Id}", updatedOrder);
        }
    }
}
