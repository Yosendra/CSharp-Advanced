// Run this program through Command Prompt. 
// Ex: app1 1 2 3 4 5

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"{args.Length} values found.");
        int sum = 0;
        foreach (var arg in args)
        {
            if (int.TryParse(arg, out int convertedValue))
            {
                sum += convertedValue;
            }
            Console.WriteLine($"out int: {convertedValue}");
        }
        Console.WriteLine($"Total of numbers: {sum}");

        Console.ReadKey();
    }
}