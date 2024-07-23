namespace StallosDotnetPleno.Api.UseCases.Customer.AddCustomer
{
    public record AddCustomerResponse(string Message, AddCustomerDataResponse Data);
    public record AddCustomerDataResponse(int Id, string Name, string Document, AddCustomerAddressResponse[] Address);
    public record AddCustomerAddressResponse(string ZipCode, string Street, string Number, string Neighborhood, string City, string UF);
}