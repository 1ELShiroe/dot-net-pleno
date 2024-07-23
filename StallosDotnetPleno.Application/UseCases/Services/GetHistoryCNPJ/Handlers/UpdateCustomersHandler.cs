using StallosDotnetPleno.Application.Interfaces.Repositories;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCNPJ.Handlers
{
    public class UpdateCustomersHandler(
        ICustomerRepository CustomerRepository) : Handler<GetHistoryCNPJUCRequest>
    {
        public override void ProcessRequest(GetHistoryCNPJUCRequest req)
        {
            Console.WriteLine("Starting to update customers");

            var countUpdate = CustomerRepository.UpdateRange(req.Customers);

            Console.WriteLine($"{countUpdate} users were changed in our database");

            Successor?.ProcessRequest(req);
        }
    }
}