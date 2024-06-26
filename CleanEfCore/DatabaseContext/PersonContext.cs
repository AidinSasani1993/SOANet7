using Microsoft.EntityFrameworkCore;

namespace CleanEfCore.DatabaseContext
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions options) : base(options)
        {
        }

        protected PersonContext()
        {
        }



        //public DbSet<Clean.Domain.Entities.Person> Person { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new CountryConfiguration());
        //    modelBuilder.ApplyConfiguration(new CarConfiguration());
        //    modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        //    modelBuilder.ApplyConfiguration(new ProductDetaileConfiguration());
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
