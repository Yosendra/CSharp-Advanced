// Async & Await
// 'async' keyword is used to make a method, lambda expression, or anonymous method as 'asynchronous method'.
//         the return type of async method is typically Task or Task<T> where T is the type of the result (actual return type).
//         the asynchronus method can be called  with 'await' keyword.
// 'await' keyword indicates a point where the method should pause its execution and wait for the result of an asynchronus method
//         and also it yields the execution control back to its caller until the awaited asynchronus method is completed.
//         The 'await' keyword can only be used within another asynchronous method

class FileWriter
{
    // Add 'async' in method definition if it contains 'await' keyword
    // Mark this as asynchronous method
    public async Task WriteFile(string fileName, string data)
    {
        StreamWriter writer = new(fileName);

        // Everytime we call async operation (in this case 'writer.WriteAsync()')
        // use 'await' keyword to make it wait for the task completion

        // Syntax Before : Task writerTask = writer.WriteAsync(data);
        await writer.WriteAsync(data);

        writer.Close();

        // The return is not needed anymore
        //return writerTask;
    }
}

class FileReader
{
    // This one also, add 'async' in method definition if it contains 'await' keyword
    // Mark this as asynchronous method
    public async Task<string> ReadFile(string fileName)
    {
        StreamReader reader = new(fileName);
        Task<string> readerTask = reader.ReadToEndAsync();
        
        // With 'await' keyword, it immediately return the actual result (in this case it is 'string') instead of Task<string>
        string content = await readerTask;
        
        reader.Close();

        // Here we don't need return the task object. We just need return the actual result
        // The compiler will automatically wrapping it into object of Task<string>
        // because ReadFile(string fileName) method we defined has return type Task<string>
        
        // Syntax before: return readerTask;
        return content;
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