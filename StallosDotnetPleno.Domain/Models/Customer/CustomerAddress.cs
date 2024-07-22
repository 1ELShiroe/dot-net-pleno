using StallosDotnetPleno.Domain.Validators.Customer;

namespace StallosDotnetPleno.Domain.Models.Customer
{
    public class CustomerAddress : Entity
    {
        public int CustomerId { get; private set; }
        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string UF { get; private set; }

        public Customer? Customer { get; private set; }

        private CustomerAddress(
            int id, int customerId, string zipCode, string street, string number, string neighborhood, string city, string uf)
        {
            Id = id;
            CustomerId = customerId;
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            UF = uf;

            Validate(this, new CustomerAddressValidator());
        }

        public static CustomerAddress New(int id, int customerId, string zipCode, string street, string number,
            string neighborhood, string city, string uf)
            => new(id, customerId, zipCode, street, number, neighborhood, city, uf);
    }
}