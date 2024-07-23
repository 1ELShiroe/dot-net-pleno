namespace StallosDotnetPleno.Api.UseCases.Customer.PutCustomer
{
    public record PutCustomerRequest(string? Name, string Document, PutCustomerAddressRequest[]? Address);
    public record PutCustomerAddressRequest(string? ZipCode, string? Street, string? Number, string? Neighborhood, string? City, string? UF);
}