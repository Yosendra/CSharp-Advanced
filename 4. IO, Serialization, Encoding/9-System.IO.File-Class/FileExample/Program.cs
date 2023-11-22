class Program
{
    public static void Main()
    {
        /// .Create()

        string directory = @"c:\practice\";

        string extension = ".txt";
        string fileName = "text1";
        string completeFileName = fileName + extension;

        string filePath = $"{directory}{completeFileName}";
        string copiedFile = $"{directory}{fileName}-copy{extension}";
        string movedFile = $"{directory}{fileName}-move{extension}";

        // File is static class
        // @ is to notify the back slash is not escape sequence character
        // With .Create(), once the file created it also opened in the memory, so that we need to close it
        // If the same file name is already exist, .Create() will overwrite it
        File.Create(filePath).Close();
        Console.WriteLine($"{completeFileName} is created ");

        /// .Exists(), .Copy(), .Move(), .Delete()

        // .Exists() is used to check if the file path is already exists or not
        bool isFileExist = File.Exists(filePath);
        if (isFileExist)
        {
            // .Copy() used to copy file
            // If the copied file is already exist, exception will be thrown
            File.Copy(filePath, copiedFile);
            Console.WriteLine($"Copy {completeFileName} to {copiedFile}");

            // .Move() can be used to rename file, or move file to another directory
            File.Move(filePath, movedFile);
            Console.WriteLine($"Moved {completeFileName} to {movedFile}");

            // .Delete() used to delete file
            File.Delete(movedFile);
            Console.WriteLine($"{movedFile} has been deleted");
        }
        else
        {
            Console.WriteLine("File not found");
        }

        Console.ReadKey();
    }
}