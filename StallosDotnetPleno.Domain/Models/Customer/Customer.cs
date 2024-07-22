using StallosDotnetPleno.Domain.Validators.Customer;
using StallosDotnetPleno.Domain.Enums;

namespace StallosDotnetPleno.Domain.Models.Customer
{
    public class Customer : Entity
    {
        public TypeUser Type { get; set; }
        public string Name { get; private set; }
        public string Document { get; private set; }

        public ICollection<CustomerAddress> Address { get; private set; } = [];

        private Customer(TypeUser type, string name, string document, ICollection<CustomerAddress> address)
        {
            Type = type;
            Name = name;
            Document = document;
            Address = address;

            Validate(this, new CustomerValidator());
        }

        public static Customer New(TypeUser type, string nome, string documento, ICollection<CustomerAddress> address)
            => new(type, nome, documento, address);
    }
}