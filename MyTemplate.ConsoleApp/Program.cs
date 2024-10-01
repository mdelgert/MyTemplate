namespace MyTemplate.ConsoleApp;

internal class Program(IServiceProvider serviceProvider, ILogger<Program> logger)
{
    private static async Task Main(string[] args)
    {
        // Get the current environment (for example, from environment variables)
        var environment = (Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "development").ToLowerInvariant();

        // Build configuration from appsettings.json
        var config = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
            .Build();

        // Configure Serilog to use configuration from appsettings.json
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(config)
            .CreateLogger();

        // Set up dependency injection
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IConfiguration>(config)
            .AddLogging(loggingBuilder => loggingBuilder.AddSerilog())
            .AddSingleton<SettingsService>()
            .AddSingleton(sp => sp.GetRequiredService<SettingsService>().GetSettings())
            .AddSingleton<HelloService>()
            .BuildServiceProvider();

        // Retrieve the logger and app
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        var program = new Program(serviceProvider, logger);

        logger.LogInformation($"Begin:");

        await program.RunAsync();

        logger.LogInformation($"End:");

        // Dispose the service provider
        await serviceProvider.DisposeAsync();
    }

    private async Task RunAsync()
    {
        // Retrieve the SettingModel from the service provider
        var settings = serviceProvider.GetRequiredService<SettingModel>();
        var helloService = serviceProvider.GetRequiredService<HelloService>();

        logger.LogInformation($"RunAsync: {settings.ExampleMessage}");

        await helloService.LogHelloAsync();
    }
}
