class FileWriter
{
    public Task WriteFile(string fileName, string data)
    {
        StreamWriter writer = new(fileName);
        Task writerTask = writer.WriteAsync(data);
        writer.Close();

        return writerTask;
    }
}

class FileReader
{
    public Task<string> ReadFile(string fileName)
    {
        StreamReader reader = new(fileName);
        Task<string> readerTask = reader.ReadToEndAsync();
        reader.Close();

        return readerTask;
    }
}

class Program
{
    public static void Main()
    {
        // Initialize
        string fileName = @"D:\Practice\C#\C#-Advanced\2. Task\15-File-IO\A.txt";
        FileWriter fileWriter = new();
        FileReader fileReader = new();

        // Write data to a file asynchronously
        Task writerTask = fileWriter.WriteFile(fileName, "These are some words contained in A.txt");

        // Because writer task is running outside of main thread, we need to wait the result before continuing the execution caused by asynchronous
        // But remember it is blocking statement (current working thread will be blocked, and the UI will be freezed), not recommended to be used
        writerTask.Wait();

        Console.WriteLine("File is written.");

        // Read data from the file asynchronously
        Task<string> readerTask = fileReader.ReadFile(fileName);
        // Wait again until the completion of operation (blocked statement)
        readerTask.Wait();

        Console.WriteLine("File is read.");
        Console.WriteLine($"File Content: {readerTask.Result}");

        Console.ReadKey();
    }
}