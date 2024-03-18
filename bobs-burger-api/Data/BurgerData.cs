using bobs_burger_api.Models;

namespace bobs_burger_api.Data
{
    public class BurgerData
    {
        private List<Product> _products = new List<Product>();
        private List<Ingredient> _ingredients = new List<Ingredient>();
        private List<User> _users = new List<User>();
        private List<Favourite> _favourites = new List<Favourite>();
        private List<Order> _orders = new List<Order>();

        private void AddIngredients()
        {
            Ingredient cheese = new Ingredient();
            cheese.Id = 1;
            cheese.Category = "burger";
            cheese.Price = 1;
            cheese.Name = "cheese";

            Ingredient buns = new Ingredient();
            buns.Id = 2;
            buns.Category = "burger";
            buns.Price = 1;
            buns.Name = "bun";

            Ingredient lettuce = new Ingredient();
            lettuce.Id = 3;
            lettuce.Category = "burger";
            lettuce.Price = 1;
            lettuce.Name = "lettuce";

            Ingredient bobsSecretSauce = new Ingredient();
            bobsSecretSauce.Id = 4;
            bobsSecretSauce.Category = "burger";
            bobsSecretSauce.Price = 2;
            bobsSecretSauce.Name = "bobs-secret-sauce";

            Ingredient beefPatty = new Ingredient();
            beefPatty.Id = 5;
            beefPatty.Category = "burger";
            beefPatty.Price = 1;
            beefPatty.Name = "beef-patty";

            Ingredient pickles = new Ingredient();
            pickles.Id = 6;
            pickles.Category = "burger";
            pickles.Price = 1;
            pickles.Name = "pickle";

            Ingredient onions = new Ingredient();
            onions.Id = 7;
            onions.Category = "burger";
            onions.Price = 1;
            onions.Name = "onion";

            Ingredient ketchup = new Ingredient();
            ketchup.Id = 8;
            ketchup.Category = "burger";
            ketchup.Price = 1;
            ketchup.Name = "ketchup";

            Ingredient mustard = new Ingredient();
            mustard.Id = 9;
            mustard.Category = "burger";
            mustard.Price = 1;
            mustard.Name = "mustard";

            _ingredients.Add(cheese);
            _ingredients.Add(buns);
            _ingredients.Add(lettuce);
            _ingredients.Add(bobsSecretSauce);
            _ingredients.Add(beefPatty);
            _ingredients.Add(pickles);
            _ingredients.Add(onions);
            _ingredients.Add(ketchup);
            _ingredients.Add(mustard);
        }

        private void AddBurgers()
        {
            Product bigBob = new Product();
            bigBob.Id = 1;
            bigBob.Category = "burger";
            bigBob.Price = 9.99;
            bigBob.Name = "Big Bob";
            bigBob.Description = "Biggest bob there is";
            bigBob.Ingredients = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

            Product quarterBob = new Product();
            quarterBob.Id = 2;
            quarterBob.Category = "burger";
            quarterBob.Price = 9.99;
            quarterBob.Name = "Quarter Bob";
            quarterBob.Description = "Biggest bob there is";
            quarterBob.Ingredients = new List<int>() { 1, 2, 4, 6, 7, 8, 9 };

            _products.Add(bigBob);
            _products.Add(quarterBob);
        }

        private void AddUsers()
        {
            User bob = new User();
            bob.Id = 1;
            bob.FirstName = "Bob";
            bob.LastName = "Burgerman";
            bob.Email = "bob@burger.com";
            bob.Phone = "12345678";
            bob.Street = "Burger Street 2";
            bob.City = "Burger Town";

            _users.Add(bob);
        }

        private void AddFavourites()
        {
            Favourite fav = new Favourite();
            fav.Id = 1;
            fav.UserId = 1;
            fav.ProductId = 1;

            _favourites.Add(fav);
        }

        private void AddOrders()
        {
            Order order = new Order();
            order.Id = 1;
            order.UserId = 1;
            order.DateTime = DateTime.UtcNow;
            order.Completed = true;
            order.ProductIds = [1, 1];
            order.Total = 20;

            _orders.Add(order);
        }

        public BurgerData() 
        {
            AddIngredients();
            AddBurgers();
            AddUsers();
            AddFavourites();
            AddOrders();
        }

        public List<Product> Products { get => _products; }
        public List<Ingredient> Ingredients { get => _ingredients; }
        public List<User> Users { get => _users; }
        public List<Favourite> Favourites { get => _favourites; }
        public List<Order> Orders { get => _orders; }
    }
}
