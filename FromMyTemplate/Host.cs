using FromMyTemplate.Services;
using FromMyTemplate.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System;

namespace FromMyTemplate;
internal static class Host
{
    private static IHost _host;

    public static void StartHost()
    {
        var logPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "FromMyTemplate", "Log.json");


        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .WriteTo.Debug(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.File(new JsonFormatter(), logPath,
                restrictedToMinimumLevel: LogEventLevel.Information,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7)
            .CreateLogger();

        _host = Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder()
            .UseSerilog()
            .ConfigureServices((_, services) =>
            {
                services.AddSingleton<IService, Service>();

                services.AddSingleton<AppDocEvents>();
            })
            .Build();

        _host.Start();
    }

    public static void StartHost(IHost host)
    {
        _host = host;
        host.Start();
    }

    public static void StopHost()
    {
        _host.StopAsync().GetAwaiter().GetResult();
        _host.Dispose();
    }

    public static T GetService<T>() where T : class
    {
        return _host.Services.GetRequiredService<T>();
    }
}
