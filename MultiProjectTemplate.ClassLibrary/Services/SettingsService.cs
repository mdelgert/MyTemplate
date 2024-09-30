namespace MultiProjectTemplate.ClassLibrary.Services;

public class SettingsService
{
    private readonly SettingModel _Settings;

    public SettingsService(IConfiguration configuration)
    {
        // Get settings from the configuration and provide a new SettingModel as fallback
        _Settings = configuration.GetSection("MultiProjectTemplateSetting").Get<SettingModel>() ?? new SettingModel();

        _Settings.ExampleMessage = string.IsNullOrWhiteSpace(_Settings.ExampleMessage) ? "HelloWorld!" : _Settings.ExampleMessage;

        _Settings.ExampleCount = _Settings.ExampleCount > 0 ? _Settings.ExampleCount : 3;
    }

    public SettingModel GetSettings()
    {
        return _Settings;
    }
}
