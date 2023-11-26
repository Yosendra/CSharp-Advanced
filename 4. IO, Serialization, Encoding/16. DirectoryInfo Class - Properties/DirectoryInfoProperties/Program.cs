class Program
{
    static void Main()
    {
        string dirPath = @"c:\practice\world";
        DirectoryInfo directoryInfo = new(dirPath);

        Console.WriteLine($"Exists? : {directoryInfo.Exists}");

        if (directoryInfo.Exists)
        {
            Console.WriteLine($"Fullname : {directoryInfo.FullName}");
            Console.WriteLine($"Name : {directoryInfo.Name}");
            Console.WriteLine($"Parent : {directoryInfo.Parent}");
            Console.WriteLine($"Root : {directoryInfo.Root}");
            Console.WriteLine($"CreationTime : {directoryInfo.CreationTime}");
            Console.WriteLine($"LastAccessTime : {directoryInfo.LastAccessTime}");
            Console.WriteLine($"LastWriteTime : {directoryInfo.LastWriteTime}");
        }
        else
        {
            Console.WriteLine("Folder not found");
        }

        Console.ReadKey();
    }
}