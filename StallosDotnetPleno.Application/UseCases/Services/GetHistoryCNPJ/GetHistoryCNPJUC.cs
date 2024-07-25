using StallosDotnetPleno.Application.UseCases.Services.GetHistoryCNPJ.Handlers;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCNPJ
{
    public class GetHistoryCNPJUC : IUseCaseAsync<GetHistoryCNPJUCRequest>
    {
        private readonly GetCustomersHandler GetCustomersHandler;

        public GetHistoryCNPJUC(
            GetCustomersHandler getCustomersHandler,
            UpdateCustomersHandler updateCustomersHandler,
            CheckCompanyHandler checkCompanyHandler)
        {
            GetCustomersHandler = getCustomersHandler;

            GetCustomersHandler
                .SetSuccessor(checkCompanyHandler)
                .SetSuccessor(updateCustomersHandler);
        }

        public async Task Execute(GetHistoryCNPJUCRequest req)
        {
            try
            {
                req.Process("GetHistoryCNPJUC", "Starting process");

                await GetCustomersHandler.ProcessRequestAsync(req);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                req.Error("GetHistoryCNPJUC", $"An error occurred during the GetHistoryCNPJUC process: {ex.Message}", ex.StackTrace ?? "");
            }
            finally
            {
                // Created method repository log and model
            }
        }
    }
}