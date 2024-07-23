namespace StallosDotnetPleno.Application.UseCases.Customer.RemoveCustomer
{
    public class RemoveCustomerUCRequest(string document)
    {
        public string Document { get; } = document;
    }
}