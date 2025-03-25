using Serilog;

namespace Framework.EndPoints.Web.Extensions.Services;

public static class SerilogConfiguration
{
    public static void AddSerilog(this WebApplicationBuilder builder, string appName,
        string abbr)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information() // <- Set the minimum level
            .Enrich.FromLogContext()
            .Enrich.WithClientIp()
            .Enrich.WithMachineName()
            .Enrich.WithEnvironmentUserName()
            .Enrich.WithProcessId()
            .Enrich.WithProcessName()
            .Enrich.WithThreadId()
            .Enrich.WithThreadName()
            .Enrich.WithCorrelationId()
            .Enrich.WithProperty("Application", appName)
            .Destructure.ToMaximumDepth(4)
            .Destructure.ToMaximumStringLength(100)
            .Destructure.ToMaximumCollectionCount(10)
            .WriteTo.Console(
                outputTemplate:
                "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} | {ClientIp} | {CorrelationId} | [{Level:u4}] | {Message:lj}{NewLine}{Exception}")
            .WriteTo.File($"logs/{builder.Environment.EnvironmentName}_{abbr}_.log",
                rollingInterval:
                RollingInterval.Hour,
                rollOnFileSizeLimit: true,
                outputTemplate:
                "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} | {ClientIp} | {CorrelationId} | [{Level:u4}] | {Message:lj}{NewLine}{Exception}")
            .CreateLogger();
        builder.Host.UseSerilog(Log.Logger);
    }
}