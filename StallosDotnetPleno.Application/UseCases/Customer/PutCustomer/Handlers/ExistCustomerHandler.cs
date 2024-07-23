using StallosDotnetPleno.Application.Interfaces.Repositories;

namespace StallosDotnetPleno.Application.UseCases.Customer.PutCustomer.Handlers
{
    public class ExistCustomerHandler(
        ICustomerRepository CustomerRepository) : Handler<PutCustomerUCRequest>
    {
        public override void ProcessRequest(PutCustomerUCRequest req)
        {
            Console.WriteLine(HandlerName, "Starting process");
            
            var existUser = CustomerRepository.GetCustomer(c => c.Document == req.NewCustomer.Document);

            if (existUser == null)
            {
                Console.WriteLine(HandlerName, $"Nenhum usuário encontrado com o documento '{req.NewCustomer.Document}'.");
                req.OutputPort?.NotFound($"Nenhum usuário encontrado com o documento '{req.NewCustomer.Document}'.");
                return;
            }

            Console.WriteLine(HandlerName, $"User found successfully document: {req.NewCustomer.Document}");

            req.SetCustomer(existUser);

            Successor?.ProcessRequest(req);
        }
    }
}