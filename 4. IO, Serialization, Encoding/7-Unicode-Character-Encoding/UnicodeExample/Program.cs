using System.Text;

class Program
{
    public static void Main()
    {
        // Unicode character in string
        string myText = "Æ";

        // Unicode character by code
        string myText2 = "\u0543";

        Console.WriteLine(myText);
        Console.WriteLine(myText2);

        string sentence = "The quick brown fox jumps over the lazy dog";

        // If you see this in debugger, each character will take two bytes.
        // Only 1 byte will given value meanwhile the other one is 0
        // since each character in this example is still supported in ASCII range (which is 1 byte)
        byte[] bytes = Encoding.Unicode.GetBytes(sentence);

        string revert = Encoding.Unicode.GetString(bytes);
        Console.WriteLine(revert);

        Console.ReadKey();
    }
}