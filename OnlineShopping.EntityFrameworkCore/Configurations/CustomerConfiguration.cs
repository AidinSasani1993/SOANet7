using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShopping.Domain.Entities;

namespace OnlineShopping.EntityFrameworkCore.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "Person");
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Code).HasColumnName("CustomerCode");
        }
    }
}
