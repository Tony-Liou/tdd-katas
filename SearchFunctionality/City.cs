namespace SearchFunctionality;

public static class City
{
    private static readonly string[] _cities =
    [
        "Paris", "Budapest", "Skopje", "Rotterdam", "Valencia", "Vancouver", "Amsterdam", "Vienna", "Sydney", "New York City", "London", "Bangkok",
        "Hong Kong", "Dubai", "Rome", "Istanbul"
    ];

    public static string[] Cities => _cities;

    public static IEnumerable<string> Search(string text)
    {
        if (text == "*")
        {
            return _cities;
        }

        if (text.Length < 2)
        {
            return Enumerable.Empty<string>();
        }

        return _cities.Where(city => city.Contains(text, StringComparison.OrdinalIgnoreCase));
    }
}