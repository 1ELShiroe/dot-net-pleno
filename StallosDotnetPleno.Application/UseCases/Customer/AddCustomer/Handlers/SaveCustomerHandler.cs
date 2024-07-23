using StallosDotnetPleno.Application.Interfaces.Repositories;

namespace StallosDotnetPleno.Application.UseCases.Customer.AddCustomer.Handlers
{
    public class SaveCustomerHandler(
        ICustomerRepository CustomerRepository) : Handler<AddCustomerUCRequest>
    {
        public override void ProcessRequest(AddCustomerUCRequest req)
        {
            Console.WriteLine(HandlerName, "Starting process");

            CustomerRepository.Add(req.Customer);

            Console.WriteLine(HandlerName, "User created successfully");

            req.OutputPort.Standard(new());

            Successor?.ProcessRequest(req);
        }
    }
}