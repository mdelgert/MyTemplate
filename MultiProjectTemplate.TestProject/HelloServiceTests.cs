//dotnet add package Moq
//dotnet add package xunit
//dotnet add package Microsoft.Extensions.Logging.Abstractions

/*
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using MultiProjectTemplate.ClassLibrary.Services;
using MultiProjectTemplate.ClassLibrary.Models;

namespace MultiProjectTemplate.TestProject;

public class HelloServiceTests
{
    [Fact]
    public async Task LogHelloAsync_ShouldLogExampleMessage()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<HelloService>>();
        var settings = new SettingModel { ExampleMessage = "Hello, World!" };
        var helloService = new HelloService(settings, mockLogger.Object);

        // Act
        await helloService.LogHelloAsync();

        // Assert
        mockLogger.Verify(logger =>
            logger.LogInformation(It.Is<string>(msg => msg.Contains("Hello, World!"))),
            Times.Once);
    }

    [Fact]
    public void GetExampleMessage_ShouldReturnExampleMessage()
    {
        // Arrange
        var settings = new SettingModel { ExampleMessage = "Test Message" };
        var mockLogger = new Mock<ILogger<HelloService>>();
        var helloService = new HelloService(settings, mockLogger.Object);

        // Act
        var result = helloService.GetExampleMessage();

        // Assert
        Assert.Equal("Test Message", result);
    }
}
*/