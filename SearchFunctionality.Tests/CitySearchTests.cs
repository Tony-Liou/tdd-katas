namespace SearchFunctionality.Tests;

public class CitySearchTests
{
    [Theory]
    [InlineData("a")]
    [InlineData("")]
    public void ReturnNoResults_WhenInputLessThanTwoCharacters(string input)
    {
        var result = City.Search(input);

        Assert.Empty(result);
    }

    [Theory]
    [InlineData("Va", new[] { "Valencia", "Vancouver" })]
    [InlineData("vA", new[] { "Valencia", "Vancouver" })]
    [InlineData("ape", new[] { "Budapest" })]
    public void ReturnResults_WhenInputIsTwoCharactersOrMore(string input, IEnumerable<string> expectedResults)
    {
        var result = City.Search(input);

        Assert.Equal(expectedResults, result);
    }

    [Fact]
    public void ReturnAll_WhenInputIsAsterisk()
    {
        var result = City.Search("*");

        Assert.Equal(City.Cities, result);
    }
}