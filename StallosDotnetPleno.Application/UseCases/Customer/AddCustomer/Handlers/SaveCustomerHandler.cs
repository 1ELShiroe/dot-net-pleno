using StallosDotnetPleno.Application.Interfaces.Repositories;

namespace StallosDotnetPleno.Application.UseCases.Customer.AddCustomer.Handlers
{
    public class SaveCustomerHandler(
        ICustomerRepository CustomerRepository) : Handler<AddCustomerUCRequest>
    {
        public override void ProcessRequest(AddCustomerUCRequest req)
        {
            Console.WriteLine(HandlerName, "Starting process...");

            var newCustomer = CustomerRepository.Add(req.Customer);

            Console.WriteLine(HandlerName, "Customer successfully created.");

            req.OutputPort?.Standard(new(
                "Usuário criado com sucesso!",
                new(newCustomer)));

            Successor?.ProcessRequest(req);
        }
    }
}
