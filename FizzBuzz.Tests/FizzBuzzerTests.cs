using FluentAssertions;

namespace FizzBuzz.Tests;

public class FizzBuzzerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GivenNumber_ReturnString()
    {
        var number = 4;
        string actual = FizzBuzzer.FizzBuzz(number);
        actual.Should().Be("4");
    }

    [Test]
    [TestCase(3, ExpectedResult = "Fizz")]
    public string GivenNumber_WhenNumberIsMultiplesOfThree_ReturnFizz(int num)
    {
        return FizzBuzzer.FizzBuzz(num);
    }

    [Test]
    [TestCase(5, "Buzz")]
    [TestCase(10, "Buzz")]
    public void GivenNumber_WhenNumberIsMultiplesOfFive_ReturnBuzz(int num, string expected)
    {
        string actual = FizzBuzzer.FizzBuzz(num);
        actual.Should().Be("Buzz");
    }

    [Test]
    [TestCase(15, "FizzBuzz")]
    [TestCase(30, "FizzBuzz")]
    public void GivenNumber_WhenNumberIsMultiplesOfThreeAndFive_ReturnFizzBuzz(int num, string expected)
    {
        string actual = FizzBuzzer.FizzBuzz(num);
        actual.Should().Be("FizzBuzz");
    }
}