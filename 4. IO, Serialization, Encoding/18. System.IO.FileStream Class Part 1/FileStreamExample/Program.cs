class Program
{
    static void Main()
    {
        string filePath = @"c:\practice\dog.txt";
        FileInfo fileInfo = new(filePath);

        // There many ways to create a file in C#, using FileStream, File, FileInfo class
        // The point to note here is the methods that are invoked returns FileStream object
        //FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write);
        //FileStream fileStream = File.Create(filePath);
        //FileStream fileStream = File.Open(filePath, FileMode.Create, FileAccess.Write);
        //FileStream fileStream = File.OpenWrite(filePath);
        //FileStream fileStream = fileInfo.Create();
        //FileStream fileStream = fileInfo.Open(FileMode.Create, FileAccess.Write);
        FileStream fileStream = fileInfo.OpenWrite();

        Console.ReadKey();
    }
}