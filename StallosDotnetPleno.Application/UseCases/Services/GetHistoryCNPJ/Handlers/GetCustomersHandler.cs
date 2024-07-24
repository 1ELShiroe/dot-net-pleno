using StallosDotnetPleno.Application.Interfaces.Repositories;
using StallosDotnetPleno.Domain.Helpers;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCNPJ.Handlers
{
    public class GetCustomersHandler(
        ICustomerRepository CustomerRepository) : Handler<GetHistoryCNPJUCRequest>
    {
        public override void ProcessRequest(GetHistoryCNPJUCRequest req)
        {
            req.Process(HandlerName, "Starting to process request to get customers with CNPJ");

            var customers = CustomerRepository.GetCustomers(c => CNPJHelper.IsValidCNPJ(c.Document));

            req.Info(HandlerName, $"Retrieved {customers.Count} customers with CNPJ from the repository");

            if (customers.Count != 0)
            {
                req.Info(HandlerName, "No customers found with CNPJ");
                return;
            }

            req.SetCustomers(customers);

            req.Info(HandlerName, "Customers set in the request object and passing to the next handler");

            Successor?.ProcessRequest(req);
        }
    }
}