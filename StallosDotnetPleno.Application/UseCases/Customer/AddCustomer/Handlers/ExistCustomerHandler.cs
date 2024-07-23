using StallosDotnetPleno.Application.Interfaces.Repositories;

namespace StallosDotnetPleno.Application.UseCases.Customer.AddCustomer.Handlers
{
    public class ExistCustomerHandler(
        ICustomerRepository CustomerRepository) : Handler<AddCustomerUCRequest>
    {
        public override void ProcessRequest(AddCustomerUCRequest req)
        {
            req.Process(HandlerName, "Starting process");

            var existUser = CustomerRepository.GetCustomer(c => c.Document == req.Customer.Document);

            if (existUser != null)
            {
                Console.WriteLine(HandlerName, $"Um usuário com o documento '{req.Customer.Document}' já existe.");
                req.OutputPort?.Error($"Um usuário com o documento '{req.Customer.Document}' já existe.");
                return;
            }
            
            req.Info(HandlerName, "No users found with the data provided");

            Successor?.ProcessRequest(req);
        }
    }
}