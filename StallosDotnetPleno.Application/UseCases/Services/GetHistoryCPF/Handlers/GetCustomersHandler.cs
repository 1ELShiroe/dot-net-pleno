using StallosDotnetPleno.Application.Interfaces.Repositories;
using StallosDotnetPleno.Domain.Helpers;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCPF.Handlers
{
    public class GetCustomersHandler(
        ICustomerRepository CustomerRepository) : Handler<GetHistoryCPFUCRequest>
    {
        public override void ProcessRequest(GetHistoryCPFUCRequest req)
        {
            req.Process(HandlerName, "Starting to process request to get customers with CPF");

            var customers = CustomerRepository.GetCustomers(c => CPFHelper.IsCPF(c.Document));

            req.Info(HandlerName, $"Retrieved {customers.Count} customers with CPF from the repository");

            if (customers.Count != 0)
            {
                req.Info(HandlerName, "No customers found with CPF");
                return;
            }

            req.SetCustomers(customers);

            req.Info(HandlerName, "Customers set in the request object and passing to the next handler");

            Successor?.ProcessRequest(req);
        }
    }
}