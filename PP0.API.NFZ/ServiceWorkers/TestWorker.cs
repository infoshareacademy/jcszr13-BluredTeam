using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PP0.API.NFZ.ServiceWorkers
{
    public class TestWorker : BackgroundService

    {
        public TestWorker(ILogger<TestWorker> logger)
        {
            _logger = logger;
        }
        private readonly TimeSpan _period = TimeSpan.FromSeconds(5);
        private readonly ILogger<TestWorker> _logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) 
        { 
            using PeriodicTimer timer = new PeriodicTimer(_period);
            while (await timer.WaitForNextTickAsync(stoppingToken)) 
            {
                _logger.LogInformation("worker działa");
            } 
        }
    }
}
