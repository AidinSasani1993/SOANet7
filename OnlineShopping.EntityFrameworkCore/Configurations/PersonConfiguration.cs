using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShopping.Domain.Entities;

namespace OnlineShopping.EntityFrameworkCore.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person", "Person");
            builder.HasKey(p => p.Id);
            builder.Property(x => x.IdentityCode).HasMaxLength(10).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Customer)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonRef);

        }
    }
}
