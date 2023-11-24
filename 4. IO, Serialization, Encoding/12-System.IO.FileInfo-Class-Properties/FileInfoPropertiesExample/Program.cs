class Program
{
    public static void Main()
    {
        string filePath = @"c:\practice\japan.txt";
        FileInfo fileInfo = new(filePath);

        if (fileInfo.Exists)
        {
            Console.WriteLine($"Exists? : {fileInfo.Exists}");
            Console.WriteLine($"Fullname : {fileInfo.FullName}");
            Console.WriteLine($"Name : {fileInfo.Name}");
            Console.WriteLine($"DirectoryName : {fileInfo.DirectoryName}");
            Console.WriteLine($"Extension : {fileInfo.Extension}");
            Console.WriteLine($"LastWriteTime : {fileInfo.LastWriteTime}");
            Console.WriteLine($"LastAccessTime : {fileInfo.LastAccessTime}");
            Console.WriteLine($"CreationTime : {fileInfo.CreationTime}");
        }
        else
        {
            Console.WriteLine("File not found");
        }

        Console.ReadKey();
    }
}