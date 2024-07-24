using StallosDotnetPleno.Application.UseCases.Services.GetHistoryCNPJ.Handlers;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCNPJ
{
    public class GetHistoryCNPJUC : IUseCase<GetHistoryCNPJUCRequest>
    {
        private readonly GetCustomersHandler GetCustomersHandler;

        public GetHistoryCNPJUC(
            GetCustomersHandler getCustomersHandler,
            CheckCepimHandler checkCepimHandler,
            CheckOfacHandler checkOfacHandler,
            UpdateCustomersHandler updateCustomersHandler)
        {
            GetCustomersHandler = getCustomersHandler;

            GetCustomersHandler
                .SetSucessor(checkCepimHandler)
                .SetSucessor(checkOfacHandler)
                .SetSucessor(updateCustomersHandler);
        }

        public void Execute(GetHistoryCNPJUCRequest req)
        {
            try
            {
                req.Process("GetHistoryCNPJUC", "Starting process");

                GetCustomersHandler.ProcessRequest(req);
            }
            catch (Exception ex)
            {
                req.Error("GetHistoryCNPJUC", $"An error occurred during the GetHistoryCNPJUC process: {ex.Message}", ex.StackTrace ?? "");
            }
            finally
            {
                // Created method repository log and model
            }
        }
    }
}