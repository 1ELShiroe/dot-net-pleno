using StallosDotnetPleno.Infrastructure.Database.Entities.Customer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace StallosDotnetPleno.Infrastructure.Database.Map.Customer
{
    public class CustomerAddressMap : IEntityTypeConfiguration<CustomerAddressEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerAddressEntity> builder)
        {
            builder.ToTable("customer_address", "StallosDotnetPleno");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Street).IsRequired();
            builder.Property(a => a.Number).IsRequired();
            builder.Property(a => a.City).IsRequired();
            builder.Property(a => a.ZipCode).IsRequired();
            builder.Property(a => a.Neighborhood).IsRequired();


            builder.HasOne(a => a.Customer)
                   .WithMany(p => p.Addresses)
                   .HasForeignKey(a => a.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}