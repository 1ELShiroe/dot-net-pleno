using StallosDotnetPleno.Application.Interfaces.Repositories;
using StallosDotnetPleno.Application.Boundaries.Customer;
using StallosDotnetPleno.Application.Boundaries;

namespace StallosDotnetPleno.Application.UseCases.Customer.RemoveCustomer
{
    public class RemoveCustomerUC(
        OutputPort<RemoveCustomerOPP> OutputPort,
        ICustomerRepository CustomerRepository) : IUseCase<RemoveCustomerUCRequest>
    {
        public void Execute(RemoveCustomerUCRequest req)
        {
            try
            {
                Console.WriteLine("RemoveCustomerUC", "Starting process");

                var existUser = CustomerRepository.GetCustomer(c => c.Document == req.Document);

                if (existUser == null)
                {
                    OutputPort.Error("Nenhum usuário encontrado com o documento informado.");
                    return;
                }

                var deleteCount = CustomerRepository.Remove(existUser);

                Console.WriteLine($"Foram deletados {deleteCount} usuário(s)");

                OutputPort.Standard(new RemoveCustomerOPP("Usuário deletado com sucesso."));
            }
            catch (Exception ex)
            {
                Console.WriteLine("RemoveCustomerUC", $"An error occurred during the RemoveCustomerUC process: {ex.Message}", ex.StackTrace ?? "");
                OutputPort.Error($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Created method repository log and model
            }
        }
    }
}