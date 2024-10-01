namespace MyTemplate.Shared.Services;

public class SettingsService
{
    private readonly SettingModel _settings;

    public SettingsService(IConfiguration configuration)
    {
        // Get settings from the configuration and provide a new SettingModel as fallback
        _settings = configuration.GetSection("MyTemplate").Get<SettingModel>() ?? new SettingModel();

        _settings.ExampleMessage = string.IsNullOrWhiteSpace(_settings.ExampleMessage) ? "HelloWorld!" : _settings.ExampleMessage;

        _settings.ExampleCount = _settings.ExampleCount > 0 ? _settings.ExampleCount : 3;
    }

    public SettingModel GetSettings()
    {
        return _settings;
    }
}
