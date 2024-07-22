using StallosDotnetPleno.Domain.Models.Customer;

namespace StallosDotnetPleno.Tests.Builders.Domain
{
    public class CustomerAddressBuilder
    {
        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        public string ZipCode { get; private set; } = string.Empty;
        public string Street { get; private set; } = string.Empty;
        public string Number { get; private set; } = string.Empty;
        public string Neighborhood { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string UF { get; private set; } = string.Empty;

        public static CustomerAddressBuilder Empty() => new();

        public CustomerAddress Build()
        {
            var model = CustomerAddress.New(Id, CustomerId, ZipCode, Street, Number, Neighborhood, City, UF);
            model.Id = Id;

            return model;
        }

        public CustomerAddressBuilder WithId(int value)
        {
            Id = value;
            return this;
        }

        public CustomerAddressBuilder WithCustomerId(int value)
        {
            CustomerId = value;
            return this;
        }

        public CustomerAddressBuilder WithZipCode(string value)
        {
            ZipCode = value;
            return this;
        }

        public CustomerAddressBuilder WithStreet(string value)
        {
            Street = value;
            return this;
        }

        public CustomerAddressBuilder WithNumber(string value)
        {
            Number = value;
            return this;
        }

        public CustomerAddressBuilder WithNeighborhood(string value)
        {
            Neighborhood = value;
            return this;
        }

        public CustomerAddressBuilder WithCity(string value)
        {
            City = value;
            return this;
        }

        public CustomerAddressBuilder WithUF(string value)
        {
            UF = value;
            return this;
        }
    }
}