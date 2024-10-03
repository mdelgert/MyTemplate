namespace MyTemplate.Shared.Models;

public class MyAppSettings
{
    // Timeout in seconds with fallback to 5 seconds
    private int _timeoutInSeconds = 5;
    public int TimeoutInSeconds
    {
        get => _timeoutInSeconds;
        set
        {
            if (value > 0)
            {
                _timeoutInSeconds = value;
            }
            else
            {
                _timeoutInSeconds = 5; // fallback if invalid
            }
        }
    }

    // Derived property for timeout in milliseconds
    public int TimeoutInMilliseconds => TimeoutInSeconds * 1000;

    // Boolean value with default fallback
    public bool IsFeatureEnabled { get; set; } = false;
}


