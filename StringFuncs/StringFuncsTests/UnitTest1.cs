namespace StringFuncsTests;
using StringFuncs;
using Xunit;

public class UnitTest1
{
    [Fact]
    public void ShouldReturnSeperatorString()
    {
        // Arrange
        string input = "hello";
        string expected = "H^E^L^L^O^";

        // Act
        string result = StringFuncs.Program.AddSeperator(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldCheckPalindrome()
    {
        // Arrange
        string input = "Madam";
        bool expected = true;

        // Act
        bool result = StringFuncs.Program.IsPalindrome(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldReturnStringLength()
    {
        // Arrange
        string input = "hello";
        int expected = 5;

        // Act
        int result = StringFuncs.Program.GetStringLength(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldReverseString()
    {
        // Arrange
        string input = "hello";
        string expected = "olleh";
        // Act
        string result = StringFuncs.Program.ReverseString(input);
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldreturnNumberOfWords()
    {
        // Arrange
        string input = "Hello World";
        int expected = 2;

        // Act
        int result = StringFuncs.Program.NumberOfWords(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldReverseWords()
    {
        // Arrange
        string input = "Hello World";
        string expected = "World Hello";

        // Act
        string result = StringFuncs.Program.ReverseWords(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldReturnDescendingString()
    {
        // Arrange
        string input = "hello";
        string expected = "ollhe";

        // Act
        string result = StringFuncs.Program.SortDescending(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public static void ShouldCompressString()
    {
        // Arrange
        string input = "aaabbbcc";
        string expected = "a3b3c2";

        // Act
        string result = StringFuncs.Program.CompressString(input);

        // Assert
        Assert.Equal(expected, result);
    }
}
