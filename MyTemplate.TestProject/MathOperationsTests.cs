namespace MyTemplate.TestProject;

public class MathOperationsTests
{
    private readonly MathOperations _mathOperations;

    public MathOperationsTests()
    {
        _mathOperations = new MathOperations();
    }

    [Fact]
    public void Add_ShouldReturnCorrectSum()
    {
        // Arrange
        int a = 5;
        int b = 3;

        // Act
        int result = _mathOperations.Add(a, b);

        // Assert
        Assert.Equal(8, result);
    }

    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(10, 5, 5)]
    [InlineData(0, 0, 0)]
    public void Subtract_ShouldReturnCorrectDifference(int a, int b, int expected)
    {
        // Act
        int result = _mathOperations.Subtract(a, b);

        // Assert
        Assert.Equal(expected, result);
    }
}