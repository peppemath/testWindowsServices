using WorkerService1;


try
{
    IHost host = Host.CreateDefaultBuilder(args)
        .UseWindowsService(options =>
        {
            options.ServiceName = "WorkerSevice (.Net 6.0)";
        })
        .ConfigureServices(services =>
        {
            services.AddHostedService<Worker>();
        })
        .Build();

    await host.RunAsync();

}
catch (Exception ex)
{
   //todo
}
finally
{
    //todo
}


