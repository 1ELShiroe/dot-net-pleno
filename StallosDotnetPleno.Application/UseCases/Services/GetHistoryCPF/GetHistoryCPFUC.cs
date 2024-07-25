using StallosDotnetPleno.Application.UseCases.Services.GetHistoryCPF.Handlers;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCPF
{
    public class GetHistoryCPFUC : IUseCaseAsync<GetHistoryCPFUCRequest>
    {
        private readonly GetCustomersHandler GetCustomersHandler;

        public GetHistoryCPFUC(
            GetCustomersHandler getCustomersHandler,
            CheckCustomerHandler checkCustomerHandler,
            UpdateCustomersHandler updateCustomersHandler)
        {
            GetCustomersHandler = getCustomersHandler;

            GetCustomersHandler
                .SetSuccessor(checkCustomerHandler)
                .SetSuccessor(updateCustomersHandler);
        }

        public async Task Execute(GetHistoryCPFUCRequest req)
        {
            try
            {
                req.Process("GetHistoryCPFUC", "Starting process");

                await GetCustomersHandler.ProcessRequestAsync(req);
            }
            catch (Exception ex)
            {
                req.Error("GetHistoryCPFUC", $"An error occurred during the GetHistoryCPFUC process: {ex.Message}", ex.StackTrace ?? "");
            }
            finally
            {
                // Created method repository log and model
            }
        }
    }
}