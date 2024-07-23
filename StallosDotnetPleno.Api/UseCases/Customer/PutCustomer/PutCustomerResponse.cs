namespace StallosDotnetPleno.Api.UseCases.Customer.PutCustomer
{
    public record PutCustomerResponse(string Message, PutCustomerDataResponse Data);
    public record PutCustomerDataResponse(int Id, string Name, string Document, PutCustomerAddressResponse[] Address);
    public record PutCustomerAddressResponse(string ZipCode, string Street, string Number, string Neighborhood, string City, string UF);
}