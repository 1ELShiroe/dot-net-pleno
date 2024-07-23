using StallosDotnetPleno.Application.UseCases.Customer.AddCustomer.Handlers;
using StallosDotnetPleno.Application.Boundaries.Customer;
using StallosDotnetPleno.Application.Boundaries;

namespace StallosDotnetPleno.Application.UseCases.Customer.AddCustomer
{
    public class AddCustomerUC : IUseCase<AddCustomerUCRequest>
    {
        private readonly OutputPort<AddCustomerOPP> OutputPort;
        private readonly ExistCustomerHandler ExistCustomerHandler;

        public AddCustomerUC(
            OutputPort<AddCustomerOPP> outputPort,
            ExistCustomerHandler existCustomerHandler,
            SaveCustomerHandler saveCustomerHandler)
        {
            OutputPort = outputPort;
            ExistCustomerHandler = existCustomerHandler;

            ExistCustomerHandler.SetSucessor(saveCustomerHandler);
        }

        public void Execute(AddCustomerUCRequest req)
        {
            try
            {
                req.Process("AddCustomerUC", "Starting process");
                req.SetOutputPort(OutputPort);

                ExistCustomerHandler.ProcessRequest(req);
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddCustomerUC", $"An error occurred during the AddCustomerUC process: {ex.Message}", ex.StackTrace ?? "");
                req.Error("AddCustomerUC", $"An error occurred during the Get Favorites process: {ex.Message}", ex.StackTrace ?? "");
            }
            finally
            {
                // Created method repository log and model
            }
        }
    }
}