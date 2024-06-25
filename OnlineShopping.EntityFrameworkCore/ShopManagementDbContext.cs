using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Domain.Entities;
using OnlineShopping.EntityFrameworkCore.Configurations;

namespace OnlineShopping.EntityFrameworkCore
{
    public class ShopManagementDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
        public DbSet<ColleagueDiscount> ColleagueDiscounts { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Person> Person { get; set; }

        public ShopManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ShopManagementDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembely = typeof(ProductCategoryConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembely);
            base.OnModelCreating(modelBuilder);
        }

    }
}
