using FizzBuzz;

int num;
if (args.Length == 0)
{
    Console.WriteLine("Please enter a number:");
    string? input = Console.ReadLine();
    num = int.Parse(input ?? throw new InvalidOperationException("No number entered."));
}
else
{
    num = int.Parse(args[0]);
}

Console.WriteLine(FizzBuzzer.FizzBuzz(num));