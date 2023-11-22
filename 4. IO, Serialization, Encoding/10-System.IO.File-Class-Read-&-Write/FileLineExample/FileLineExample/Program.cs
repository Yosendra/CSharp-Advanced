class Program
{
    static void Main()
    {
        List<string> asia = new()
        {
            "Indonesia", "Singapore", "Malaysia",
        };

        // WriteAllLines
        string filePath = @"c:\practice\asia.txt";
        File.WriteAllLines(filePath, asia);
        Console.WriteLine("asia.txt created");

        // ReadAllLines
        string[] asiaCountries = File.ReadAllLines(filePath);
        foreach (var country in asiaCountries)
        {
            Console.WriteLine(country);
        }

        Console.ReadKey();
    }
}