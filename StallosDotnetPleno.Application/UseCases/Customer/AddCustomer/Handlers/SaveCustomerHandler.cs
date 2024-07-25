using StallosDotnetPleno.Application.Interfaces.Repositories;
using StallosDotnetPleno.Application.Interfaces.Services;

namespace StallosDotnetPleno.Application.UseCases.Customer.AddCustomer.Handlers
{
    public class SaveCustomerHandler(
        ICustomerRepository CustomerRepository,
        IJWTService JWT) : Handler<AddCustomerUCRequest>
    {
        public override void ProcessRequest(AddCustomerUCRequest req)
        {
            req.Process(HandlerName, "Starting process...");

            var newCustomer = CustomerRepository.Add(req.Customer);

            var token = JWT.Generate(newCustomer);

            req.Info(HandlerName, "Customer successfully created.");

            req.OutputPort?.Standard(new(
                "Usuário criado com sucesso!",
                new(newCustomer, token)));

            Successor?.ProcessRequest(req);
        }
    }
}
