class Program
{
    public static void Main()
    {
        int _decimal = 289;
        
        string _octal = Convert.ToString(_decimal, 8);      // Decimal to Octal
        Console.WriteLine(_octal);

        _decimal = Convert.ToInt32(_octal, 8);              // Octal to Decimal
        Console.WriteLine(_decimal);

        // There is no literal value for Octal number in C#

        Console.ReadKey();
    }
}