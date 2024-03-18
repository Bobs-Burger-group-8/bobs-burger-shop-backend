using bobs_burger_api.Models;
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
            modelBuilder.Entity<Product>().HasKey(s => s.Id);

            BurgerData burgerData = new BurgerData();
            modelBuilder.Entity<Product>().HasData(burgerData.Products);
        }

        public DbSet<Product> Products { get; set; }
    }
}
