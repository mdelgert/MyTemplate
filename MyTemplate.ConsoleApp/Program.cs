using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyTemplate.Shared.Models;
using MyTemplate.Shared.Services;
using Serilog;

namespace MyTemplate.ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        // Allow passing environment via command-line argument or set from environment variables.
        var environment = args.Length > 0 ? args[0].ToLowerInvariant() :
            (Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "production").ToLowerInvariant();

        // Build configuration
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{environment}.json", true, true)
            .AddEnvironmentVariables()
            .Build();

        // Configure Serilog from appsettings.json
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration) // Load configuration from appsettings.json
            .CreateLogger();

        try
        {
            Log.Information("Starting the console app");

            // Create a Host for the console app
            var host = Host.CreateDefaultBuilder(args)
                .UseSerilog() // Use Serilog as the logging provider
                .ConfigureAppConfiguration((context, config) =>
                {
                    var env = (Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "production")
                        .ToLowerInvariant();

                    Log.Information($"Loading configuration for {env} environment");

                    config.AddJsonFile("appsettings.json", true, true)
                          .AddJsonFile($"appsettings.{env}.json", true, true);

                    config.AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                    // Bind MyAppSettings from configuration with validation
                    services.AddOptions<SettingsModel>()
                        .Bind(context.Configuration.GetSection("MyAppTemplate"));

                    // Register the application service
                    services.AddTransient<TemplateService>();
                    services.AddTransient<ExampleService>();
                })
                .Build();

            // Resolve the service and run the app logic
            var service = host.Services.GetRequiredService<TemplateService>();
            var example = host.Services.GetRequiredService<ExampleService>();

            example.Hello();
            service.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "An error occurred while starting the application");
        }
        finally
        {
            Log.CloseAndFlush(); // Ensure that all logs are flushed before exit
        }
    }
}