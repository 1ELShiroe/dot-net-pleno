using StallosDotnetPleno.Application.Interfaces.Repositories;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCPF.Handlers
{
    public class UpdateCustomersHandler(
        ICustomerRepository CustomerRepository) : HandlerAsync<GetHistoryCPFUCRequest>
    {
        public override Task ProcessRequestAsync(GetHistoryCPFUCRequest req)
        {
            req.Process(HandlerName, "Starting to update customers");

            var countUpdate = CustomerRepository.UpdateRange(req.Customers);

            req.Info(HandlerName, $"{countUpdate} users were changed in our database");

            Successor?.ProcessRequestAsync(req);
            return Task.CompletedTask;
        }
    }
}