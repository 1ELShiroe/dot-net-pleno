using StallosDotnetPleno.Domain.Validators.Customer;
using StallosDotnetPleno.Domain.Enums;

namespace StallosDotnetPleno.Domain.Models.Customer
{
    public class Customer : Entity
    {
        public TypeUser Type { get; set; }
        public string Name { get; private set; }
        public string Document { get; private set; }

        public ICollection<CustomerAddress> Addresses { get; private set; } = [];

        private Customer(TypeUser type, string name, string document, ICollection<CustomerAddress> addresses)
        {
            Type = type;
            Name = name;
            Document = document;
            Addresses = addresses;

            Validate(this, new CustomerValidator());
        }

        public static Customer New(TypeUser type, string nome, string documento, ICollection<CustomerAddress> addresses)
            => new(type, nome, documento, addresses);

        public void SetAddresses(ICollection<CustomerAddress> addresses) => Addresses = addresses;
    }
}