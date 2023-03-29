using WorkerService.Application.Interfaces;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEmail _email;
        private readonly IHttpService _httpService;
        private readonly IHostApplicationLifetime _applicationLifetime;

        public Worker(ILogger<Worker> logger, IEmail email, IHttpService httpService, IHostApplicationLifetime applicationLifetime)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _email = email ?? throw new ArgumentNullException(nameof(email));
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            _applicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var statusSite = await _httpService.ChecksStatusSite("https://localhost:7190/");

                if(statusSite != System.Net.HttpStatusCode.OK)
                {
                    _email.SendEmail("TESTE@hotmail.com", "Worker Service Test", $"Site not running at: {DateTimeOffset.Now}");
                    _applicationLifetime.StopApplication();
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}