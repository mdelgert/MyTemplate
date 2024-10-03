using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using MyTemplate.Shared.Models;
using System.Text.Json;

namespace MyTemplate.Shared.Services;

public class TemplateService
{
    private readonly SettingsModel _settings;
    private readonly ILogger<TemplateService> _logger;

    public TemplateService(IOptions<SettingsModel> settings, ILogger<TemplateService> logger)
    {
        _settings = settings.Value;
        _logger = logger;
    }

    public void Run()
    {
        // Print settings in JSON format
        PrintSettings();

        // Log information about the settings
        _logger.LogInformation("Timeout in milliseconds: {Timeout}", _settings.TimeoutInSeconds);
        _logger.LogInformation("Is feature enabled: {IsFeatureEnabled}", _settings.IsFeatureEnabled);

        try
        {
            if (_settings.IsFeatureEnabled)
            {
                _logger.LogDebug("Feature is enabled. Executing feature logic...");
            }
            else
            {
                _logger.LogDebug("Feature is disabled.");
            }

            // Simulate some work
            Thread.Sleep(_settings.TimeoutInSeconds);
            _logger.LogInformation("Completed processing.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred during execution");
        }
    }

    // Method to print SettingsModel as JSON
    private void PrintSettings()
    {
        var formattedSettings = JsonSerializer.Serialize(_settings, new JsonSerializerOptions
        {
            WriteIndented = true // Enable formatted (indented) JSON
        });

        _logger.LogInformation("Current settings: {Settings}", formattedSettings);
    }
}