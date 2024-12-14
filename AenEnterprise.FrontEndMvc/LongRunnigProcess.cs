namespace AenEnterprise.FrontEndMvc
{
    public class LongRunnigProcess : BackgroundService
    {
        private ILogger<LongRunnigProcess> logger;
        public LongRunnigProcess(ILogger<LongRunnigProcess> logger)
        {
            this.logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Long process running started");
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("long running process starting at {time}: " + DateTime.Now);
                ProcessRuningRuningAsync(stoppingToken);
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }

            logger.LogInformation("Long process running Stoped");
        }

        public async void ProcessRuningRuningAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(5000, stoppingToken);
            logger.LogInformation("long running process running at {time}: " + DateTime.Now);
        }
    }
}
