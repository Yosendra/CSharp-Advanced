// (Continuation) The last project is already working. Here we just rewriting it to be more simple and concise to reduce more lines

class FileWriter
{
    public async Task WriteFile(string fileName, string data)
    {
        // We can use 'using' statement to automatically dispose resource object without invoke .Close() method explicitly
        using (StreamWriter writer = new(fileName))
        {
            // Here immediately use await operator instead of assigning it to object 'Task'
            await writer.WriteAsync(data);
        }
    }
}

class FileReader
{
    public async Task<string> ReadFile(string fileName)
    {
        // We can use 'using' statement to automatically dispose resource object without invoke .Close() method explicitly
        using (StreamReader reader = new(fileName))
        {
            // Syntax Before :
            //  Task<string> readerTask = reader.ReadToEndAsync();
            //  string content = await readerTask;

            // writing 'await' and assigning the result in single line
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

        // Syntax Before:
        //  Task writerTask = fileWriter.WriteFile(fileName, "These are some words contained in A.txt");
        //  await writerTask;

        // Invoke and await in single line
        await fileWriter.WriteFile(fileName, "These are some words contained in A.txt");

        Console.WriteLine("File is written.");

        // Syntax Before:
        //  Task<string> readerTask = fileReader.ReadFile(fileName);
        //  await readerTask;

        // writing 'await' and assigning the result in single line
        string content = await fileReader.ReadFile(fileName);

        Console.WriteLine("File is read.");
        Console.WriteLine($"File Content: {content}");

        Console.ReadKey();
    }
}