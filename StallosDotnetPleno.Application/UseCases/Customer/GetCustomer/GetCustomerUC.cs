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
                req.Process("GetCustomerUC", $"Starting process get customerId: {req.Id}");

                var existUser = CustomerRepository.GetCustomer(c => c.Id == req.Id);

                if (existUser == null)
                {
                    req.Info("GetCustomerUC", $"Customer with ID {req.Id} not found");
                    OutputPort.NotFound("Nenhum usuário encontrado com o ID informado.");
                    return;
                }

                req.Info("GetCustomerUC", $"Customer with ID {req.Id} retrieved successfully");
                OutputPort.Standard(new("Usuário encontrado com sucesso.", new(existUser)));
            }
            catch (Exception ex)
            {
                req.Error("GetCustomerUC", $"An error occurred during the GetCustomerUC process: {ex.Message}", ex.StackTrace ?? "");
                OutputPort.Error($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Created method repository log and model
            }
        }
    }
}