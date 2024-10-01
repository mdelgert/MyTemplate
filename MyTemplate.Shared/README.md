# Project Title: MyTemplate.ClassLibrary

_A brief tagline: A .NET project template for creating class libraries with integrated Serilog logging and hosting._

## Description

**MyTemplate.ClassLibrary** is a .NET 8 project template designed to help developers quickly create class libraries with a robust logging and hosting setup. The project template leverages `Microsoft.Extensions.Hosting` and Serilog for structured logging, enabling developers to easily create reusable class libraries for various types of applications.

## Dependencies

This project uses the following dependencies:

- **Microsoft.Extensions.Hosting**: Provides the foundational framework for creating long-running services and managing dependency injection in .NET.
  
- **Serilog.Extensions.Logging**: Allows Serilog to work with the built-in logging system in .NET, providing structured logging capabilities.
  
- **Serilog.Sinks.File**: Enables logging to a file, which is useful for retaining logs over time for debugging and audits.
  
- **Serilog.Sinks.Console**: Facilitates logging to the console, making it easier to see real-time logs during development and testing.
  
- **Serilog.Settings.Configuration**: Configures Serilog using `appsettings.json`, allowing for a flexible and environment-specific logging setup.

## Prerequisites

To run this project, you’ll need the following:

- **.NET SDK 8.0 or higher**: [Download here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- An IDE that supports .NET development:
  - Visual Studio 2022
  - Visual Studio Code
  - JetBrains Rider

## Installation

To install the necessary dependencies, use the following commands in your project directory:

```bash
dotnet add package Microsoft.Extensions.Hosting
dotnet add package Serilog.Extensions.Logging
dotnet add package Serilog.Sinks.File
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Settings.Configuration
```

These commands will add the necessary logging and hosting packages to your project.

## Configuration

To configure Serilog, edit the `appsettings.json` file. Below is an example configuration that sets up logging to the console and a rolling file log:

```json
{
  "Serilog": {
    "MinimumLevel": "Information",
    "WriteTo": [
      { "Name": "Console" },
      {
        "Name": "File",
        "Args": { "path": "Logs/classlib.log", "rollingInterval": "Day" }
      }
    ]
  }
}
```

This configuration writes logs to both the console and a file located at `Logs/classlib.log`, with daily rolling files.

## Usage

In your `Program.cs` file, set up logging and hosting like this:

```csharp
using Microsoft.Extensions.Hosting;
using Serilog;

class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build())
            .CreateLogger();

        try
        {
            Log.Information("Starting up the host");

            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog()  // Add Serilog to the hosting pipeline
            .ConfigureServices((hostContext, services) =>
            {
                // Add your services here
            });
}
```

### Explanation:

- `Log.Logger`: Initializes Serilog with the settings from `appsettings.json`.
- `UseSerilog()`: Integrates Serilog with the hosting setup.
- The logs will be written to the console and file as per the configuration.
---