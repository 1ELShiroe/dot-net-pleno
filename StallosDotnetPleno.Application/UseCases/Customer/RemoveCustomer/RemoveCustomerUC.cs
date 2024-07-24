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
                req.Process("RemoveCustomerUC", "Starting process");

                var existUser = CustomerRepository.GetCustomer(c => c.Document == req.Document);

                if (existUser == null)
                {
                    req.Info("RemoveCustomerUC", $"Customer with Document {req.Document} not found");
                    OutputPort.NotFound("Nenhum usuário encontrado com o documento informado.");
                    return;
                }

                var deleteCount = CustomerRepository.Remove(existUser);

                req.Info("RemoveCustomerUC", $"Foram deletados {deleteCount} usuário(s)");

                OutputPort.Standard(new RemoveCustomerOPP("Usuário deletado com sucesso."));
            }
            catch (Exception ex)
            {
                req.Error("RemoveCustomerUC", $"An error occurred during the RemoveCustomerUC process: {ex.Message}", ex.StackTrace ?? "");
                OutputPort.Error($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Created method repository log and model
            }
        }
    }
}