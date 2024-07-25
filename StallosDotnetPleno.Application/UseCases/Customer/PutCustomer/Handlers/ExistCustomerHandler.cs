using StallosDotnetPleno.Application.Interfaces.Repositories;

namespace StallosDotnetPleno.Application.UseCases.Customer.PutCustomer.Handlers
{
    public class ExistCustomerHandler(
        ICustomerRepository CustomerRepository) : Handler<PutCustomerUCRequest>
    {
        public override void ProcessRequest(PutCustomerUCRequest req)
        {
            req.Process(HandlerName, "Starting process");

            var existUser = CustomerRepository.GetCustomer(c => c.Id == req.NewCustomer.Id);

            if (existUser == null)
            {
                req.Info(HandlerName, $"Customer with Id: {req.NewCustomer.Id} not found");
                req.OutputPort?.NotFound($"Nenhum usuário encontrado com o Id: '{req.NewCustomer.Id}'.");
                return;
            }

            req.Info(HandlerName, $"User found successfully Id: {req.NewCustomer.Id}");

            req.SetCustomer(existUser);

            Successor?.ProcessRequest(req);
        }
    }
}