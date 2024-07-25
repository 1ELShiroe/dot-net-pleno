using StallosDotnetPleno.Application.UseCases.Services.GetHistoryCNPJ;
using StallosDotnetPleno.Application.UseCases;

namespace StallosDotnetPleno.Services.Services
{
    public class GetHistoryCNPJService(
        ILogger<GetHistoryCPFService> Logger,
        IUseCaseAsync<GetHistoryCNPJUCRequest> UseCase) : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.LogInformation("GetHistoryCNPJService is starting.");

            stoppingToken.Register(() =>
                Logger.LogInformation("GetHistoryCNPJService is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                Logger.LogInformation("Starting processing GetHistoryCNPJService at {time}", DateTimeOffset.Now);

                try
                {
                    Console.WriteLine("INICIADO");

                    await UseCase.Execute(new());

                    await Task.Delay(1000 * 60, stoppingToken);
                }
                catch (TaskCanceledException)
                {
                    Logger.LogWarning("Task was cancelled.");
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, "An error occurred while processing GetHistoryCNPJService");
                }
            }

            Logger.LogInformation("GetHistoryCNPJService has stopped.");
        }
    }
}
