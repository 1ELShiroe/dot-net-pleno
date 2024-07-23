namespace StallosDotnetPleno.Api.UseCases.Customer.GetCustomer
{
    public record GetCustomerResponse(string Message, GetCustomerDataResponse Data);
    public record GetCustomerDataResponse(int Id, string Type, string Name, string Document, GetCustomerAddressResponse[] Address);
    public record GetCustomerAddressResponse(string ZipCode, string Street, string Number, string Neighborhood, string City, string UF);
}