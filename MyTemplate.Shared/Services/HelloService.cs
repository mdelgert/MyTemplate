namespace MyTemplate.Shared.Services;

public class HelloService(SettingModel settings, ILogger<HelloService> logger)
{
    public async Task LogHelloAsync()
    {
        try
        {
            // Simulate async operation
            await Task.Delay(1);

            logger.LogInformation($"LogHelloAsync: {settings.ExampleMessage}");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred during LogHelloAsync.");
            throw;
        }
    }
}