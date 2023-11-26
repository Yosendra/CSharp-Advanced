using System.Text;

class Program
{
    public static void Main()
    {
        char ch = 'A';

        // For ASCII, byte type is enough
        // Look at ASCII table for integer representation for each character

        byte b = (byte)ch;
        Console.WriteLine(b);       // Output: 65

        ch = (char)b;
        Console.WriteLine(ch);      // Output: A

        // Generate all characters in ASCII
        const int upperLimit = 128;
        byte[] bytes = new byte[upperLimit];
        for (byte i = 0; i < upperLimit; i++)
        {
            bytes[i] = i;
        }

        // Use built in static function from Encoding class in System.Text namespace
        string str = Encoding.ASCII.GetString(bytes);

        // Specify the output encoding of displayed text in the Console
        Console.OutputEncoding = Encoding.ASCII;
        Console.WriteLine(str);

        // string to byte[]
        string sentence = "The quick brown fox jumps over the lazy dog";
        byte[] byteArray = Encoding.ASCII.GetBytes(sentence);

        // Convert back from byte array to string
        string revertString = Encoding.ASCII.GetString(byteArray);
        Console.WriteLine(revertString);

        Console.ReadKey();
    }
}