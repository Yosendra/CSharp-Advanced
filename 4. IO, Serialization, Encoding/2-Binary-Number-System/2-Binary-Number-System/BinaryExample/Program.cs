class Program
{
    public static void Main()
    {
        // This is in decimal (base 10) format by default
        int dec1 = 13;

        // Try to convert the number into binary format using .ToString() static method in Convert class
        // There are many method overload of this method for converting to different base (e.g. 2, 8, 10, 16)
        // InvalidArgumentException will be thrown if the base is other than 4 mentioned above  
        
        string _binary = Convert.ToString(dec1, 2);  // Decimal to Binary
        Console.WriteLine(_binary);

        // You can look at the intellisense for more method overload provided by C#
        int _decimal = Convert.ToInt32(value: _binary, fromBase: 2);  // Binary to Int
        Console.WriteLine(_decimal);

        // Literal -> the value you directly write in the program, without accepting the value by user (e.g. through input keyboard)
        var string_literal = "Halo"; // "Halo" is the literal for string
        var binary_literal = 0b1101; // 0b1101 is the literal for binary number, prefix by 0b or 0B. This will be automatically converted to integer type when we assigned
        Console.WriteLine(string_literal);
        Console.WriteLine(binary_literal);

        Console.ReadKey();
    }
}