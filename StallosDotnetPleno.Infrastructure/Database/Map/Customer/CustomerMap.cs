using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace StallosDotnetPleno.Infrastructure.Database.Map.Customer
{
    public class CustomerMap : IEntityTypeConfiguration<Entities.Customer.Customer>
    {
        public void Configure(EntityTypeBuilder<Entities.Customer.Customer> builder)
        {
            builder.ToTable("customer", "StallosDotnetPleno");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Type).IsRequired().HasConversion<string>();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Document).IsRequired();

            builder.HasMany(a => a.Addresses)
                   .WithOne(p => p.Customer)
                   .HasForeignKey(a => a.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}