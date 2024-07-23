using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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

        [JsonIgnore]
        public Customer? Customer { get; private set; }

        private CustomerAddress(
          int customerId, string zipCode, string street, string number, string neighborhood, string city, string uf)
        {
            CustomerId = customerId;
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            UF = uf;

            Validate(this, new CustomerAddressValidator());
        }

        public static CustomerAddress New(int customerId, string zipCode, string street, string number,
            string neighborhood, string city, string uf)
            => new(customerId, zipCode, street, number, neighborhood, city, uf);
    }
}