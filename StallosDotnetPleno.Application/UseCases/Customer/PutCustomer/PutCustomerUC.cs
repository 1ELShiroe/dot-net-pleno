using StallosDotnetPleno.Application.UseCases.Customer.PutCustomer.Handlers;
using StallosDotnetPleno.Application.Boundaries.Customer;
using StallosDotnetPleno.Application.Boundaries;

namespace StallosDotnetPleno.Application.UseCases.Customer.PutCustomer
{
    public class PutCustomerUC : IUseCase<PutCustomerUCRequest>
    {
        private readonly OutputPort<PutCustomerOPP> OutputPort;
        private readonly ExistCustomerHandler ExistCustomerHandler;

        public PutCustomerUC(
            OutputPort<PutCustomerOPP> outputPort,
            ExistCustomerHandler existCustomerHandler,
            MountCustomerHandler mountCustomerHandler,
            ValidateCustomerHandler validateCustomerHandler,
            UpdateCustomerHandler updateCustomerHandler)
        {
            OutputPort = outputPort;
            ExistCustomerHandler = existCustomerHandler;

            ExistCustomerHandler
                .SetSucessor(mountCustomerHandler)
                .SetSucessor(validateCustomerHandler)
                .SetSucessor(updateCustomerHandler);
        }

        public void Execute(PutCustomerUCRequest req)
        {
            try
            {
                req.Process("PutCustomerUC", "Starting process");
                req.SetOutputPort(OutputPort);

                ExistCustomerHandler.ProcessRequest(req);

                req.Info("PutCustomerUC", "Starting Finished");
            }
            catch (Exception ex)
            {
                req.Error("PutCustomerUC", $"An error occurred during the PutCustomerUC process: {ex.Message}", ex.StackTrace ?? "");
                OutputPort.Error($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Created method repository log and model
            }
        }
    }
}