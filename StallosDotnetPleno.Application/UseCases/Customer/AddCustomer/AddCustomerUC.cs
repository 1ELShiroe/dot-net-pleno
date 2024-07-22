using StallosDotnetPleno.Application.Boundaries;
using StallosDotnetPleno.Application.Boundaries.Customer;

namespace StallosDotnetPleno.Application.UseCases.Customer.AddCustomer
{
    public class AddCustomerUC : IUseCase<AddCustomerUCRequest>
    {
        private readonly OutputPort<AddCustomerOPP> OutputPort;

        public void Execute(AddCustomerUCRequest req)
        {
            try
            {
                Console.WriteLine("GetViewersUC", "Starting process");

            }
            catch (Exception ex)
            {
                Console.WriteLine("AddCustomerUC", $"An error occurred during the AddCustomerUC process: {ex.Message}", ex.StackTrace ?? "");
                OutputPort.Error($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Created method repository log and model
            }
        }
    }
}