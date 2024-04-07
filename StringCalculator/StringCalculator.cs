namespace StringCalculator;

public class StringCalculator
{
    public static int Add(string input)
    {
        if (input is "")
            return 0;

        string[] separators;
        if (input.StartsWith("//"))
        {
            int idx = input.IndexOf('\n');
            separators = [input.Substring(2, idx - 2)];
            input = input[(idx + 1)..];
        }
        else
        {
            separators = [",", "\n"];
        }

        var numbersArr = input.Split(separators, StringSplitOptions.None);
        int sum = 0;
        foreach (string s in numbersArr)
        {
            try
            {
                sum += int.Parse(s);
            }
            catch (FormatException e)
            {
                // Default separators
                if (separators.Length == 2)
                {
                    throw;
                }

                var err = FindInvalidSeparator(input, separators[0]);
                throw new FormatException($"'{separators[0]}' expected but '{err.unresolvedChar}' found at position {err.pos}.");
            }
        }

        return sum;
    }

    private static (string unresolvedChar, int pos) FindInvalidSeparator(string input, string separator)
    {
        for (var i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (char.IsDigit(c))
            {
                continue;
            }

            if (c != separator[0])
            {
                return (c.ToString(), i);
            }
        }

        throw new ArgumentException("Invalid character not found", nameof(input));
    }
}