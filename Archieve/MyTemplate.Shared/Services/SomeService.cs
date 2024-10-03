using Microsoft.Extensions.Options;

namespace MyTemplate.Shared.Services;

public class SomeService
{
    private readonly MyAppSettings _settings;

    public SomeService(IOptions<MyAppSettings> settings)
    {
        _settings = settings.Value;
    }

    public void Run()
    {
        // Access the timeout value and boolean flag
        int timeout = _settings.TimeoutInMilliseconds;
        bool isFeatureEnabled = _settings.IsFeatureEnabled;

        Console.WriteLine($"Timeout in milliseconds: {timeout}");
        Console.WriteLine($"Is feature enabled: {isFeatureEnabled}");
    }
}

