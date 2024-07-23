using Microsoft.EntityFrameworkCore;
using StallosDotnetPleno.Infrastructure.Database.Entities.Customer;
using StallosDotnetPleno.Infrastructure.Database.Map.Customer;

namespace StallosDotnetPleno.Infrastructure.Database
{
    public class Context : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<CustomerAddressEntity> CustomerAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = Environment.GetEnvironmentVariable("DBCONN");
            
            if (!string.IsNullOrEmpty(connection))
                optionsBuilder.UseSqlServer(connection, options =>
                {
                    options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), []);
                    options.MigrationsHistoryTable("_MigrationHistory", "StallosDotnetPleno");
                }).EnableSensitiveDataLogging();
            else optionsBuilder.UseInMemoryDatabase("StallosDotnetPleno");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new CustomerAddressMap());
        }
    }
}