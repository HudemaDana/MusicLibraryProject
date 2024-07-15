using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MusicLibrary.Services.Interfaces;

namespace MusicLibrary.Services.Extension
{
    public class JsonImportHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<JsonImportHostedService> _logger;

        public JsonImportHostedService(IServiceScopeFactory serviceScopeFactory, ILogger<JsonImportHostedService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting JSON import...");

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var jsonImportService = scope.ServiceProvider.GetRequiredService<IJsonImportService>();

                try
                {
                    // Use the path to the JSON file
                    string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.json");
                    await jsonImportService.ImportArtistsFromJsonAsync(jsonFilePath);
                    _logger.LogInformation("JSON import completed successfully.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred during JSON import.");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}

