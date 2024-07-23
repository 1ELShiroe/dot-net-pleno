using StallosDotnetPleno.Application.Interfaces.Repositories;
using StallosDotnetPleno.Application.Boundaries.Customer;
using StallosDotnetPleno.Application.Boundaries;

namespace StallosDotnetPleno.Application.UseCases.Customer.GetCustomer
{
    public class GetCustomerUC(
        OutputPort<GetCustomerOPP> OutputPort,
        ICustomerRepository CustomerRepository) : IUseCase<GetCustomerUCRequest>
    {
        public void Execute(GetCustomerUCRequest req)
        {
            try
            {
                Console.WriteLine("GetCustomerUC", $"Starting process get customerId: {req.Id}");

                var existUser = CustomerRepository.GetCustomer(c => c.Id == req.Id);

                if (existUser == null)
                {
                    Console.WriteLine("GetCustomerUC", $"Customer with ID {req.Id} not found");
                    OutputPort.NotFound("Nenhum usuário encontrado com o ID informado.");
                    return;
                }

                Console.WriteLine("GetCustomerUC", $"Customer with ID {req.Id} retrieved successfully");
                OutputPort.Standard(new("Usuário deletado com sucesso.", new(existUser)));
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetCustomerUC", $"An error occurred during the GetCustomerUC process: {ex.Message}", ex.StackTrace ?? "");
                OutputPort.Error($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Created method repository log and model
            }
        }
    }
}