namespace StallosDotnetPleno.Services.Services
{
    public class GetHistoryCNPJService(ILogger<GetHistoryCPFService> Logger) : BackgroundService
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
