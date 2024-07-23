using StallosDotnetPleno.Domain.Models.Customer;
using StallosDotnetPleno.Domain.Enums;

namespace StallosDotnetPleno.Tests.Builders.Domain
{
    public class CustomerBuilder
    {
        private readonly CustomerAddressBuilder AddressBuilder = CustomerAddressBuilder.Empty();

        public int Id { get; private set; }
        public TypeUser Type { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Document { get; private set; } = string.Empty;
        public List<CustomerAddressModel> Addresses { get; private set; } = [];

        public static CustomerBuilder Empty() => new();

        public CustomerModel Build()
        {
            var model = CustomerModel.New(Type, Name, Document, Addresses);
            model.Id = Id;

            return model;
        }

        public CustomerBuilder WithId(int id)
        {
            Id = id;
            return this;
        }

        public CustomerBuilder WithName(string value)
        {
            Name = value;
            return this;
        }

        public CustomerBuilder WithDocument(string value)
        {
            Document = value;
            return this;
        }

        public CustomerBuilder WithType(TypeUser type)
        {
            Type = type;
            return this;
        }

        public CustomerBuilder WithAddresses(List<Action<CustomerAddressBuilder>> actions)
        {
            foreach (var action in actions)
            {
                action(AddressBuilder);
                Addresses.Add(AddressBuilder.Build());
            }
            
            return this;
        }
    }
}