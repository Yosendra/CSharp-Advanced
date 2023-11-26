class MyClass
{
    public static void Main()
    {
        string filePath = @"c:\practice\dog.txt";
        string content = "The dog is one of the common domestic animal.";

        // WriteAllText
        File.WriteAllText(filePath, content);
        Console.WriteLine("dog.txt created");

        // ReadAllText
        // This will read all the text in the file to a single string
        // even when there are new lines in it.
        // You can see it in the debugger.
        content = File.ReadAllText(filePath);
        Console.WriteLine(content);

        Console.ReadKey();
    }
}