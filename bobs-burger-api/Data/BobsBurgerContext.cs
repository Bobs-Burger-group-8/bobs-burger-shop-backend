using bobs_burger_api.Models;
using bobs_burger_api.Models.Favourites;
using bobs_burger_api.Models.Ingredients;
using bobs_burger_api.Models.Orders;
using bobs_burger_api.Models.Products;
using bobs_burger_api.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace bobs_burger_api.Data
{
    public class BobsBurgerContext : DbContext
    {
        private string _connectionString;
        public BobsBurgerContext()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
        }
        public BobsBurgerContext(DbContextOptions<BobsBurgerContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            // this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favourite>()
                .HasOne(fave => fave.User)
                .WithMany(user => user.Favourites)
                .HasForeignKey(fave => fave.UserId);

            modelBuilder.Entity<Favourite>()
                .HasOne(fave => fave.Product)
                .WithMany(product => product.Favourites)
                .HasForeignKey(fave => fave.ProductId);

            modelBuilder.Entity<Order>()
                .HasOne(order => order.User)
                .WithMany(user => user.Orders)
                .HasForeignKey(order => order.UserId);

            BurgerData burgerData = new BurgerData();
            modelBuilder.Entity<Product>().HasData(burgerData.Products);
            modelBuilder.Entity<Ingredient>().HasData(burgerData.Ingredients);
            modelBuilder.Entity<User>().HasData(burgerData.Users);
            modelBuilder.Entity<Favourite>().HasData(burgerData.Favourites);
            modelBuilder.Entity<Order>().HasData(burgerData.Orders);
        }
    }
}
