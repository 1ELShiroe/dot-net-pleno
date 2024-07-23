namespace StallosDotnetPleno.Application.UseCases.Customer.GetCustomer
{
    public class GetCustomerUCRequest(int id)
    {
        public int Id { get; } = id;
    }
}