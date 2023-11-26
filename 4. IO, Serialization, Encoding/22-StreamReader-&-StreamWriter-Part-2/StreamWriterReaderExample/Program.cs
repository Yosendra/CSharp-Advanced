// The advantage of using StreamWriter and StreamReader classes is you don't need to manually convert the string to byte array. It automatically done.
// Disadvantage it only works on based text file

using System.IO;

class Program
{
    static void Main()
    {
        string filePath = @"c:\practice\europe.txt";
        FileInfo fileInfo = new(filePath);
        //StreamWriter streamWriter = new(filePath);

        // This is filestream's manual close version 
        //FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write);
        //StreamWriter streamWriter = new(fileStream);
        //streamWriter.WriteLine("Hello");
        //// It also close filestream
        //streamWriter.Close();

        // This is using statement version
        //FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write);
        //using (StreamWriter streamWriter = new(fileStream))
        //{
        //    streamWriter.WriteLine("Hello");
        //}

        // This is FileInfo version
        using (StreamWriter streamWriter = fileInfo.CreateText())
        {
            streamWriter.WriteLine("Rusia has population about 145,934,000");
            // some code here
            streamWriter.WriteLine("Germany has population about 83,783,000");
            // another some code also here
            streamWriter.WriteLine("United Kingdom has population about 67,886,000");
        }
        Console.WriteLine("europe.txt created");

        // StreamReader
        //StreamReader streamReader = new(filePath);
        //FileStream fileStream = new(filePath, FileMode.Open, FileAccess.Read);
        //StreamReader streamReader = new(fileStream);
        using (StreamReader streamReader = fileInfo.OpenText())
        {
            Console.WriteLine("\nFile read. File content is:");

            // Read full line as a single string
            //string contentFromFile = streamReader.ReadToEnd();
            //Console.WriteLine(contentFromFile);

            // Read part-by-part (10 characters)
            char[] buffer = new char[10];
            int charCount;
            do
            {
                charCount = streamReader.Read(buffer, 0, buffer.Length);
                string readByPartResult = new string(buffer);
                Console.WriteLine(readByPartResult);
            } 
            while (charCount != 0);
        }

        Console.ReadKey();
    }
}