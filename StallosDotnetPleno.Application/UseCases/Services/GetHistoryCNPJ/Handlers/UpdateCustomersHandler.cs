using StallosDotnetPleno.Application.Interfaces.Repositories;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCNPJ.Handlers
{
    public class UpdateCustomersHandler(
        ICustomerRepository CustomerRepository) : HandlerAsync<GetHistoryCNPJUCRequest>
    {
        public override async Task ProcessRequestAsync(GetHistoryCNPJUCRequest req)
        {
            req.Process(HandlerName, "Starting to update customers");

            var countUpdate = CustomerRepository.UpdateRange(req.Customers);

            req.Info(HandlerName, $"{countUpdate} users were changed in our database");

            if (Successor != null)
                await Successor.ProcessRequestAsync(req);
        }
    }
}