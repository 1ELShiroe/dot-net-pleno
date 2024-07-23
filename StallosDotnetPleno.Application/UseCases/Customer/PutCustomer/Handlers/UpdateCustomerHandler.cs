using StallosDotnetPleno.Application.Interfaces.Repositories;

namespace StallosDotnetPleno.Application.UseCases.Customer.PutCustomer.Handlers
{
    public class UpdateCustomerHandler(
        ICustomerRepository CustomerRepository) : Handler<PutCustomerUCRequest>
    {
        public override void ProcessRequest(PutCustomerUCRequest req)
        {
            Console.WriteLine(HandlerName, "Starting process");

            CustomerRepository.Update(req.Customer!);

            var customers = CustomerRepository.GetCustomer(c => c.Document == req.Customer!.Document);

            req.OutputPort?.Standard(new(
                "Usuário atualizado com sucesso!",
                new(customers)));

            Console.WriteLine(HandlerName, $"Customer with ID: {req.Customer!.Document} updated successfully");

            Successor?.ProcessRequest(req);
        }
    }
}