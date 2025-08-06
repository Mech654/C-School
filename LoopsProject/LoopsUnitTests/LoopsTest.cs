namespace LoopsUnitTests;

public class LoopsTest
{

    public void Test1()
    {

    }
    [Fact]
    public void ShouldReturnBiggestNember()
    {
        // Arrange
        int[] numbers = { 1, 2, 3, 5, 10, 1 };
        int expected = 10;

        // Act
        int result = LoopsProject.Program.BiggestNumber(numbers);

        // Assert
        Assert.Equal(expected, result);
    }
    [Fact]
    public void ShouldReturnSevensCount()
    {
        // Arrange
        int[] numbers = { 3, 3, 3, 7, 7, 2 };
        int expected = 2;

        // Act
        int result = LoopsProject.Program.Sevens(numbers);

        // Assert
        Assert.Equal(expected, result);
    }
    [Fact]
    public void ShouldReturnAdjacentCheck()
    {
        // Arrange
        int[] numbers = { 1, 2, 1, 2, 3 };
        bool expected = true;

        // Act
        bool result = LoopsProject.Program.isAdjacent(numbers);

        // Assert
        Assert.Equal(expected, result);
    }
    [Fact]
    public void ShouldReturnPrimeNumbers()
    {
        // Arrange
        int limit = 100;
        var expected = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        // Act
        var result = LoopsProject.Program.PrimeNumbers(limit);

        // Assert
        Assert.Equal(expected, result);
    }
    [Fact]
    public void ShouldReturnPrimteNumbers2()
    {
        // Arrange
        int limit = 50;
        var expected = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 };

        // Act
        var result = LoopsProject.Program.PrimeNumbers(limit);

        // Assert
        Assert.Equal(expected, result);
    }
    [Fact]
    public void ShouldExtractString()
    {
        // Arrange
        string input = "##Hello##";
        string expected = "Hello";

        // Act
        string result = LoopsProject.Program.ExtractString(input);

        // Assert
        Assert.Equal(expected, result);
    }
    [Fact]
    public void ShouldReturnFullSequence()
    {
        // Arrange
        string input = "ds";
        string expected = "defghijklmnopqrs";

        // Act
        string result = LoopsProject.Program.FullSequenceOfLetters(input);

        // Assert
        Assert.Equal(expected, result);
    }
}
