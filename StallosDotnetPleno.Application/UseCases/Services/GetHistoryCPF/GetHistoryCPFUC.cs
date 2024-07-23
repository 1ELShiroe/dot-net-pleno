using StallosDotnetPleno.Application.UseCases.Services.GetHistoryCPF.Handlers;

namespace StallosDotnetPleno.Application.UseCases.Services.GetHistoryCPF
{
    public class GetHistoryCPFUC : IUseCase<GetHistoryCPFUCRequest>
    {
        private readonly GetCustomersHandler GetCustomersHandler;

        public GetHistoryCPFUC(
            GetCustomersHandler getCustomersHandler,
            CheckBolsaFamiliaHandler checkBolsaFamiliaHandler,
            CheckPepHandler checkPepHandler,
            CheckInterpol checkInterpol,
            UpdateCustomersHandler updateCustomersHandler)
        {
            GetCustomersHandler = getCustomersHandler;

            GetCustomersHandler
                .SetSucessor(checkBolsaFamiliaHandler)
                .SetSucessor(checkPepHandler)
                .SetSucessor(checkInterpol)
                .SetSucessor(updateCustomersHandler);
        }

        public void Execute(GetHistoryCPFUCRequest req)
        {
            try
            {
                Console.WriteLine("GetHistoryCPFUC", "Starting process");

                GetCustomersHandler.ProcessRequest(req);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetHistoryCPFUC", $"An error occurred during the GetHistoryCPFUC process: {ex.Message}", ex.StackTrace ?? "");
            }
            finally
            {
                // Created method repository log and model
            }
        }
    }
}