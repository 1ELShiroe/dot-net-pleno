using StallosDotnetPleno.Domain.Enums;

namespace StallosDotnetPleno.Api.UseCases.Customer.AddCustomer
{
    public record CustomerAddressRequest(string ZipCode, string Street, string Number, string Neighborhood, string City, string UF);
    public record AddCustomerRequest(TypeUser Type, string Name, string Document, CustomerAddressRequest[] Addresses);
}