
class FileWriter
{
    public async Task WriteFile(string fileName, string data)
    {
        using (StreamWriter writer = new(fileName))
        {
            await writer.WriteAsync(data);
        }
    }
}

class FileReader
{
    public async Task<string> ReadFile(string fileName)
    {
        // Simulate an exception
        // The exception here will be propagated to the caller thread or the caller task
        throw new NotSupportedException();

        using (StreamReader reader = new(fileName))
        {
            string content = await reader.ReadToEndAsync();
            return content;
        }
    }
}

class Program
{
    public static async Task Main()
    {
        string fileName = @"A.txt";
        FileWriter fileWriter = new();
        FileReader fileReader = new();

        await fileWriter.WriteFile(fileName, "These are some words contained in A.txt");
        Console.WriteLine("File is written.");

        // Use try-catch to handle the exception gracefully
        try
        {
            string content = await fileReader.ReadFile(fileName);
            Console.WriteLine("File is read.");
            Console.WriteLine($"File Content: {content}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }
}