using StallosDotnetPleno.Domain.Validators.Customer;
using StallosDotnetPleno.Domain.Enums;
using System.Text.RegularExpressions;

namespace StallosDotnetPleno.Domain.Models.Customer
{
    public class CustomerModel : Entity
    {
        public TypeUser Type { get; set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public List<string> Histories { get; private set; } = [];

        public ICollection<CustomerAddressModel> Addresses { get; private set; } = [];

        private CustomerModel(TypeUser type, string name, string document, ICollection<CustomerAddressModel> addresses)
        {
            Type = type;
            Name = name;
            Document = RemovePunctuation(document);
            Addresses = addresses;

            Validate(this, new CustomerValidator());
        }

        public static CustomerModel New(TypeUser type, string name, string document, ICollection<CustomerAddressModel> addresses)
            => new(type, name, document, addresses);

        public void SetAddresses(ICollection<CustomerAddressModel> addresses) => Addresses = addresses;

        private static string RemovePunctuation(string document)
        {
            return Regex.Replace(document, @"[^\w\d]", string.Empty);
        }
    }
}