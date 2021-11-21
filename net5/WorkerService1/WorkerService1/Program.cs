using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureServices((hostContext, services) =>
        //        {
        //            services.AddHostedService<Worker>();
        //        });

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureServices((hostContext, services) =>
        //        {
        //            services.AddHostedService<Worker>()
        //            .Configure<EventLogSettings>(config =>
        //            {
        //                config.LogName = "Sample Service";
        //                config.SourceName = "Sample Service Source";
        //            });
        //        });

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(options =>
                    options.AddFilter<EventLogLoggerProvider>(level => level >= LogLevel.Information)
                )
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>()
                    .Configure<EventLogSettings>(config =>
                    {
                        config.LogName = "Sample Service";
                        config.SourceName = "Sample Service Source";
                    });
                }).UseWindowsService();
    }
}
