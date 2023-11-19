class Program
{
    public static void Main()
    {
        int _decimal = 742;
        
        string _hexadecimal = Convert.ToString(_decimal, 16);       // Decimal to Hexadecimal
        Console.WriteLine(_hexadecimal);

        _decimal = Convert.ToInt32(_hexadecimal, 16);               // Hexadecimal to Decimal
        Console.WriteLine(_decimal);

        // Hexadecimal literal
        var hexadecimal_literal = 0x64;
        Console.WriteLine(hexadecimal_literal);

        Console.ReadKey();
    }
}