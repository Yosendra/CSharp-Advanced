// FileInfo vs File
// In Fileinfo, there is no need for you to supply filePath many times
// at each invocation of its method since it is stored in the object when we pass the filePath in the constructor
// Meanwhile in File class, it is needed to supply filePath in each invocation of its static method.

class Program
{
    static void Main()
    {
        string filePath = @"c:\practice\japan.txt";
        string destinationPath = @"c:\practice\another japan.txt";
        string destinationPath2 = @"c:\practice\something else japan.txt";

        // The difference between File and FileInfo class is
        // File is static, meanwhile FileInfo is not static.
        // So you need to instantiate FileInfo class in order to use it.
        FileInfo fileInfo = new(filePath);

        // Create()
        fileInfo.Create().Close();
        Console.WriteLine("japan.txt created");

        // CopyTo()
        // CopyTo() return FileInfo class instance, it refers to the new copied object
        FileInfo copiedFile = fileInfo.CopyTo(destinationPath);
        Console.WriteLine(copiedFile.Name + " created");

        // MoveTo()
        copiedFile.MoveTo(destinationPath2);
        Console.WriteLine(copiedFile.Name + " moved");

        // Delete()
        copiedFile.Delete();
        Console.WriteLine(copiedFile.Name + " deleted");

        Console.ReadKey();
    }
}