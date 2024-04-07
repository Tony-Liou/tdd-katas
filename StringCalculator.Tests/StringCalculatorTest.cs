using FluentAssertions;

namespace StringCalculator.Tests;

public class StringCalculatorTest
{
    [Fact]
    public void ShouldReturnZero_WhenStringIsEmpty()
    {
        var input = string.Empty;

        int actual = StringCalculator.Add(input);

        actual.Should().Be(0);
    }

    [Fact]
    public void ShouldReturnLiteralValue_WhenStringHasOneNumber()
    {
        var input = "1";

        int actual = StringCalculator.Add(input);

        actual.Should().Be(1);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,3,4", 9)]
    [InlineData("1,2,3,4,5", 15)]
    public void ShouldReturnSum_WhenStringHasMultipleNumbers(string numbers, int expected)
    {
        int actual = StringCalculator.Add(numbers);

        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("1,2\n3", 6)]
    public void GivenMultipleNumbers_WhenUsingNewLineDelimiter_ShouldReturnSum(string numbers, int expected)
    {
        int actual = StringCalculator.Add(numbers);

        actual.Should().Be(expected);
    }

    [Fact]
    public void ShouldThrowException_WhenSeparatorAtEnd()
    {
        var input = "1,2,";

        Action action = () => StringCalculator.Add(input);

        action.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("//;\n1;3", 4)]
    [InlineData("//|\n1|2|3", 6)]
    [InlineData("//sep\n2sep5", 7)]
    public void GivenCustomDelimiter_WhenUsingCustomDelimiter_ShouldReturnSum(string numbers, int expected)
    {
        int actual = StringCalculator.Add(numbers);

        actual.Should().Be(expected);
    }

    [Fact]
    public void GivenCustomDelimiter_WhenNumbersStringContainInvalidSeparator_ShouldThrowExceptionWithMessage()
    {
        const string input = "//|\n1|2,3";

        Action action = () => StringCalculator.Add(input);

        action.Should().Throw<Exception>()
            .WithMessage("'|' expected but ',' found at position 3.");
    }
}