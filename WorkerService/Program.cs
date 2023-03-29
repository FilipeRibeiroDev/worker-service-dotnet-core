using WorkerService;
using WorkerService.Application.Interfaces;
using WorkerService.Application.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>()
        .AddSingleton<IEmail, Email>()
        .AddSingleton<IHttpService, HttpService>();
    })
    .Build();

host.Run();
