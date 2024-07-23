namespace StallosDotnetPleno.Services.Services
{
    public class GetHistoryCPFService(ILogger<GetHistoryCPFService> Logger) : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.LogInformation("GetHistoryCPFService is starting.");

            stoppingToken.Register(() =>
                Logger.LogInformation("GetHistoryCPFService is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                Logger.LogInformation("Starting processing update GetHistoryCPFService at {time}", DateTimeOffset.Now);

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
                    Logger.LogError(ex, "An error occurred while processing GetHistoryCPFService.");
                }
            }

            Logger.LogInformation("GetHistoryCPFService has stopped.");
        }
    }
}
