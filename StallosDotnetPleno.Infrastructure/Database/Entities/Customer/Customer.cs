using StallosDotnetPleno.Domain.Enums;

namespace StallosDotnetPleno.Infrastructure.Database.Entities.Customer
{
    public class Customer
    {
        public int Id { get; set; }
        public TypeUser Type { get; set; }
        public string? Name { get; private set; }
        public string? Document { get; private set; }

        public ICollection<CustomerAddress> Addresses { get; private set; } = [];
    }
}