
// C# still support Command Line Argument in top level statement

// Access 'args' variable immediately
Console.WriteLine(args.Length);

// Assume first argument is a filePath
if (args.Length > 0)
{
    if (File.Exists(args[0]))
    {
        string content = File.ReadAllText(args[0]);
        Console.WriteLine(content);
    }
    else
    {
        Console.WriteLine("File not found");
    }
}
else
{
    Console.WriteLine("FilePath is expected.");
}
Console.Write("\nPress any key to exit...");
Console.ReadKey();