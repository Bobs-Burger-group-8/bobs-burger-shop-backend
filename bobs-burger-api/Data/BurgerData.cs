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
            cheese.Id = (int) IngredientEnum.Cheese;
            cheese.Category = "burger";
            cheese.Price = 1;
            cheese.Name = "cheese";

            Ingredient buns = new Ingredient();
            buns.Id = (int) IngredientEnum.Bun;
            buns.Category = "burger";
            buns.Price = 1;
            buns.Name = "bun";

            Ingredient lettuce = new Ingredient();
            lettuce.Id = (int)IngredientEnum.Lettuce;
            lettuce.Category = "burger";
            lettuce.Price = 1;
            lettuce.Name = "lettuce";

            Ingredient bobsSecretSauce = new Ingredient();
            bobsSecretSauce.Id = (int)IngredientEnum.BobsSecretSauce;
            bobsSecretSauce.Category = "burger";
            bobsSecretSauce.Price = 2;
            bobsSecretSauce.Name = "bobs-secret-sauce";

            Ingredient beefPatty = new Ingredient();
            beefPatty.Id = (int)IngredientEnum.BeefPatty;
            beefPatty.Category = "burger";
            beefPatty.Price = 1;
            beefPatty.Name = "beef-patty";

            Ingredient pickles = new Ingredient();
            pickles.Id = (int)IngredientEnum.Pickle;
            pickles.Category = "burger";
            pickles.Price = 1;
            pickles.Name = "pickle";

            Ingredient onions = new Ingredient();
            onions.Id = (int)IngredientEnum.Onion;
            onions.Category = "burger";
            onions.Price = 1;
            onions.Name = "onion";

            Ingredient ketchup = new Ingredient();
            ketchup.Id = (int)IngredientEnum.Ketchup;
            ketchup.Category = "burger";
            ketchup.Price = 1;
            ketchup.Name = "ketchup";

            Ingredient mustard = new Ingredient();
            mustard.Id = (int)IngredientEnum.Mustard;
            mustard.Category = "burger";
            mustard.Price = 1;
            mustard.Name = "mustard";

            Ingredient bacon = new Ingredient();
            bacon.Id = (int)IngredientEnum.Bacon;
            bacon.Category = "burger";
            bacon.Price = 2;
            bacon.Name = "bacon";

            Ingredient tomato = new Ingredient();
            tomato.Id = (int)IngredientEnum.Tomato;
            tomato.Category = "burger";
            tomato.Price = 2;
            tomato.Name = "tomato";

            _ingredients.Add(cheese);
            _ingredients.Add(buns);
            _ingredients.Add(lettuce);
            _ingredients.Add(bobsSecretSauce);
            _ingredients.Add(beefPatty);
            _ingredients.Add(pickles);
            _ingredients.Add(onions);
            _ingredients.Add(ketchup);
            _ingredients.Add(mustard);
            _ingredients.Add(bacon);
            _ingredients.Add(tomato);
        }

        private void AddBurgers()
        {
            Product bigBob = new Product();
            bigBob.Id = 1;
            bigBob.Category = "burger";
            bigBob.Price = 9.99;
            bigBob.Name = "Big Bob";
            bigBob.Description = "Biggest bob there is";
            bigBob.Ingredients = new List<int>() 
            { 
                (int) IngredientEnum.Cheese,
                (int) IngredientEnum.Bun,
                (int) IngredientEnum.Lettuce,
                (int) IngredientEnum.BobsSecretSauce,
                (int) IngredientEnum.BeefPatty, 
                (int) IngredientEnum.Pickle,
                (int) IngredientEnum.Onion
            };
            bigBob.Image = "https://s7d1.scene7.com/is/image/mcdonalds/Header_BigMac_832x472:product-header-desktop?wid=830&hei=456&dpr=off";

            Product quarterBob = new Product();
            quarterBob.Id = 2;
            quarterBob.Category = "burger";
            quarterBob.Price = 6.99;
            quarterBob.Name = "Quarter Bob";
            quarterBob.Description = "A quarter of a bob";
            quarterBob.Ingredients = new List<int>() 
            {
                (int) IngredientEnum.Cheese,
                (int) IngredientEnum.Bun, 
                (int) IngredientEnum.BobsSecretSauce,
                (int) IngredientEnum.Pickle,
                (int) IngredientEnum.Onion,
                (int) IngredientEnum.Ketchup,
                (int) IngredientEnum.Mustard
            };
            quarterBob.Image = "https://s7d1.scene7.com/is/image/mcdonalds/DC_202201_0007-005_QuarterPounderwithCheese_832x472:product-header-desktop?wid=830&hei=458&dpr=off";

            Product baconBob = new Product
            {
                Id = 9,
                Category = "burger",
                Price = 8.49,
                Name = "Bacon Bob",
                Description = "A delicious bob with bacon",
                Ingredients = new List<int>()
                {
                    (int)IngredientEnum.Cheese,
                    (int)IngredientEnum.Bun,
                    (int)IngredientEnum.Bacon,
                    (int)IngredientEnum.BeefPatty,
                    (int)IngredientEnum.Tomato,
                    (int)IngredientEnum.Onion,
                    (int)IngredientEnum.BobsSecretSauce
                },
                Image = "https://cdn-bk-no-ordering.azureedge.net/media/5gmlysib/bacon-cheddar.png"
            };

            Product wobber = new Product
            {
                Id = 10,
                Category = "burger",
                Price = 8.99,
                Name = "Whobber",
                Description = "A delicious bob that whobbs",
                Ingredients = new List<int>()
                {
                    (int)IngredientEnum.Bun,
                    (int)IngredientEnum.BeefPatty,
                    (int)IngredientEnum.Tomato,
                    (int)IngredientEnum.Onion,
                    (int)IngredientEnum.Pickle,
                    (int)IngredientEnum.BobsSecretSauce
                },
                Image = "https://cdn-bk-no-ordering.azureedge.net/media/mm3bavh3/whopper.png"
            };

            Product chickenBob = new Product
            {
                Id = 11,
                Category = "burger",
                Price = 7.99,
                Name = "Chicken Bob",
                Description = "A delicious bob with chicken",
                Ingredients = new List<int>()
                {
                    (int)IngredientEnum.Bun,
                    (int)IngredientEnum.ChickenPatty,
                    (int)IngredientEnum.Lettuce,
                    (int)IngredientEnum.BobsSecretSauce
                },
                Image = "https://cdn-bk-no-ordering.azureedge.net/media/iszprrh2/kingse52000307-02_bk_crispy_chicken_web_produktbilde_500x540px.png"
            };

            Product fishyBob = new Product
            {
                Id = 12,
                Category = "burger",
                Price = 6.49,
                Name = "Fishy Bob",
                Description = "A delicious bob with fish",
                Ingredients = new List<int>()
                {
                    (int)IngredientEnum.Bun,
                    (int)IngredientEnum.FishPatty,
                    (int)IngredientEnum.Lettuce,
                    (int)IngredientEnum.BobsSecretSauce
                },
                Image = "https://cdn-bk-no-ordering.azureedge.net/media/vekb5nxb/fish-king.png"
            };

            _products.Add(bigBob);
            _products.Add(quarterBob);
            _products.Add(baconBob);
            _products.Add(wobber);
            _products.Add(chickenBob);
            _products.Add(fishyBob);
        }

        private void AddSides()
        {
            Product fries = new Product
            {
                Id = 13,
                Category = "sides",
                Price = 2.99,
                Name = "Bob Fries",
                Description = "Delicious bob fries",
                Image = "https://cdn-bk-no-ordering.azureedge.net/media/ftef2wdw/bk_kiosk_400x290_fries_l.png"
            };

            Product nuggets = new Product
            {
                Id = 14,
                Category = "sides",
                Price = 3.49,
                Name = "Bob Nuggets",
                Description = "Delicious bob nuggets",
                Image = "https://s7d1.scene7.com/is/image/mcdonalds/DC_202006_0483_4McNuggets_Stacked_832x472:product-header-desktop?wid=830&hei=458&dpr=off"
            };

            _products.Add(fries); 
            _products.Add(nuggets);
        }

        private void AddDrinks()
        {
            Product cola = new Product
            {
                Id = 3,
                Category = "drink",
                Price = 3.49,
                Name = "Coca Cola",
                Image = "https://cdn-bk-no-ordering.azureedge.net/media/e5oifjqh/bk_kiosk_400x290_cocacola_m.png",
                Description = "Coca Cola"
            };

            Product fanta = new Product
            {
                Id = 4,
                Category = "drink",
                Price = 3.49,
                Name = "Fanta",
                Image = "https://cdn-bk-no-ordering.azureedge.net/media/pr0bwbks/bk_kiosk_400x290_fanta_m.png",
                Description = "Fanta"
            };

            Product sprite = new Product
            {
                Id = 5,
                Category = "drink",
                Price = 3.49,
                Name = "Sprite",
                Image = "https://cdn-bk-no-ordering.azureedge.net/media/05tfhl04/bk_kiosk_400x290_sprite_m.png",
                Description = "Sprite"
            };

            Product water = new Product
            {
                Id = 6,
                Category = "drink",
                Price = 3.49,
                Name = "Water",
                Image = "https://cdn-bk-no-ordering.azureedge.net/media/snhee5on/bk_medium_1100x1024_telemark-naturell-kullsyre-1.png",
                Description = "Water"
            };

            Product coffee = new Product
            {
                Id = 7,
                Category = "drink",
                Price = 3.49,
                Name = "Coffee",
                Image = "https://cdn-bk-no-ordering.azureedge.net/media/wwqpjvvl/kaffe-stor-400x290px.png",
                Description = "Coffee"
            };

            Product cappuccino = new Product
            {
                Id = 8,
                Category = "drink",
                Price = 3.49,
                Name = "Cappuccino",
                Image = "https://cdn-bk-no-ordering.azureedge.net/media/zohl0we4/cappuccino-stor-400x290px.png",
                Description = "Cappuccino"
            };

            _products.Add(cola);
            _products.Add(fanta);
            _products.Add(sprite);
            _products.Add(water);
            _products.Add(coffee);
            _products.Add(cappuccino);
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
            AddDrinks();
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
