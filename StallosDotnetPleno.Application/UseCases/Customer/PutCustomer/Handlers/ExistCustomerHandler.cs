using StallosDotnetPleno.Application.Interfaces.Repositories;

namespace StallosDotnetPleno.Application.UseCases.Customer.PutCustomer.Handlers
{
    public class ExistCustomerHandler(
        ICustomerRepository CustomerRepository) : Handler<PutCustomerUCRequest>
    {
        public override void ProcessRequest(PutCustomerUCRequest req)
        {
            req.Process(HandlerName, "Starting process");

            var existUser = CustomerRepository.GetCustomer(c => c.Document == req.NewCustomer.Document);

            if (existUser == null)
            {
                req.Info(HandlerName, $"Nenhum usuário encontrado com o documento '{req.NewCustomer.Document}'.");
                req.OutputPort?.NotFound($"Nenhum usuário encontrado com o documento '{req.NewCustomer.Document}'.");
                return;
            }

            req.Info(HandlerName, $"User found successfully document: {req.NewCustomer.Document}");

            req.SetCustomer(existUser);

            Successor?.ProcessRequest(req);
        }
    }
}