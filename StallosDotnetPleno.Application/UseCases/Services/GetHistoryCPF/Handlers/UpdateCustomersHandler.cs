using StallosDotnetPleno.Application.Interfaces.Repositories;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCPF.Handlers
{
    public class UpdateCustomersHandler(
        ICustomerRepository CustomerRepository) : Handler<GetHistoryCPFUCRequest>
    {
        public override void ProcessRequest(GetHistoryCPFUCRequest req)
        {
            Console.WriteLine("Starting to update customers");

            var countUpdate = CustomerRepository.UpdateRange(req.Customers);

            Console.WriteLine($"{countUpdate} users were changed in our database");

            Successor?.ProcessRequest(req);
        }
    }
}