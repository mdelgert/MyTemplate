namespace MyTemplate.Shared.Services;

public class ExampleService(SettingsModel settings, ILogger<TemplateService> logger)
{
    public void Hello()
    {
        logger.LogInformation("Message: {Message}", settings.Message);
    }
}
