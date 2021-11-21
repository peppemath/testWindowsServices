using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        Random _rnd;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _rnd = new Random();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var x = _rnd.Next(0, 10);
                if( x<5)
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                else
                    _logger.LogWarning("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
