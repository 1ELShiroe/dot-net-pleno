using StallosDotnetPleno.Application.UseCases.Customer.AddCustomer.Handlers;
using StallosDotnetPleno.Application.Boundaries.Customer;
using StallosDotnetPleno.Application.Boundaries;
using StallosDotnetPleno.Application.Interfaces.Services;

namespace StallosDotnetPleno.Application.UseCases.Customer.AddCustomer
{
    public class AddCustomerUC : IUseCase<AddCustomerUCRequest>
    {
        private readonly OutputPort<AddCustomerOPP> OutputPort;
        private readonly ExistCustomerHandler ExistCustomerHandler;
        private readonly IRosterService Roster;

        public AddCustomerUC(
            IRosterService roster,
            OutputPort<AddCustomerOPP> outputPort,
            ExistCustomerHandler existCustomerHandler,
            SaveCustomerHandler saveCustomerHandler)
        {
            Roster = roster;
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
                Console.WriteLine(ex);
                req.Error("AddCustomerUC", $"An error occurred during the AddCustomerUC process: {ex.Message}", ex.StackTrace ?? "");
            }
            finally
            {
                // Created method repository log and model
            }
        }
    }
}