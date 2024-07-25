using StallosDotnetPleno.Domain.Enums;

namespace StallosDotnetPleno.Infrastructure.Database.Entities.Customer
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public TypeUser Type { get; set; }
        public string? Name { get; private set; }
        public string? Document { get; private set; }
        public List<string> Histories { get; private set; } = [];

        public ICollection<CustomerAddressEntity> Addresses { get; private set; } = [];
    }
}