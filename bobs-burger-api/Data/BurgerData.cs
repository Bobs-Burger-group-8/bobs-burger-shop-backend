using bobs_burger_api.Models;

namespace bobs_burger_api.Data
{
    public class BurgerData
    {
        private List<Product> _products = new List<Product>();

        private void AddIngredients()
        {
            Product cheese = new Product();
            cheese.Id = 1;
            cheese.Category = "ingredient";
            cheese.Price = 1;
            cheese.Name = "cheese";
            cheese.Description = "Deliciously melted cheese";

            Product buns = new Product();
            buns.Id = 2;
            buns.Category = "ingredient";
            buns.Price = 1;
            buns.Name = "bun";
            buns.Description = "No better buns exist";

            Product lettuce = new Product();
            lettuce.Id = 3;
            lettuce.Category = "ingredient";
            lettuce.Price = 1;
            lettuce.Name = "lettuce";
            lettuce.Description = "Very green";

            Product bobsSecretSauce = new Product();
            bobsSecretSauce.Id = 4;
            bobsSecretSauce.Category = "ingredient";
            bobsSecretSauce.Price = 2;
            bobsSecretSauce.Name = "bobs-secret-sauce";
            bobsSecretSauce.Description = "Bobs super special, super secret burger sauce";

            Product beefPatty = new Product();
            beefPatty.Id = 5;
            beefPatty.Category = "ingredient";
            beefPatty.Price = 1;
            beefPatty.Name = "beef-patty";
            beefPatty.Description = "100% juicy meat";

            Product pickles = new Product();
            pickles.Id = 6;
            pickles.Category = "ingredient";
            pickles.Price = 1;
            pickles.Name = "pickle";
            pickles.Description = "Fermented for days";

            Product onions = new Product();
            onions.Id = 7;
            onions.Category = "ingredient";
            onions.Price = 1;
            onions.Name = "onion";
            onions.Description = "Could make you cry";

            Product ketchup = new Product();
            ketchup.Id = 8;
            ketchup.Category = "ingredient";
            ketchup.Price = 1;
            ketchup.Name = "ketchup";
            ketchup.Description = "Very red";

            Product mustard = new Product();
            mustard.Id = 9;
            mustard.Category = "ingredient";
            mustard.Price = 1;
            mustard.Name = "mustard";
            mustard.Description = "Very yellow";

            _products.Add(cheese);
            _products.Add(buns);
            _products.Add(lettuce);
            _products.Add(bobsSecretSauce);
            _products.Add(beefPatty);
            _products.Add(pickles);
            _products.Add(onions);
            _products.Add(ketchup);
            _products.Add(mustard);
        }

        private void AddBurgers()
        {
            Product bigBob = new Product();
            bigBob.Id = 10;
            bigBob.Category = "burger";
            bigBob.Price = 9.99;
            bigBob.Name = "Big Bob";
            bigBob.Description = "Biggest bob there is";
            bigBob.Ingredients = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

            Product quarterBob = new Product();
            quarterBob.Id = 11;
            quarterBob.Category = "burger";
            quarterBob.Price = 9.99;
            quarterBob.Name = "Quarter Bob";
            quarterBob.Description = "Biggest bob there is";
            quarterBob.Ingredients = new List<int>() { 1, 2, 4, 6, 7, 8, 9 };

            _products.Add(bigBob);
            _products.Add(quarterBob);
        }

        public BurgerData() 
        {
            AddIngredients();
            AddBurgers();
            foreach(var burg in  _products)
            {
                Console.WriteLine(burg.Id);
            }
        }

        public List<Product> Products { get => _products; }
    }
}
