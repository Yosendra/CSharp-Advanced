﻿using System.Text;

// It is better to create one file stream for writing and another one reading
// It is not advisable to perform both operation in the same file stream

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
        FileStream fileStream = fileInfo.Open(FileMode.Create, FileAccess.Write);
        //FileStream fileStream = fileInfo.OpenWrite();

        // Content
        string content = "Dog is one of the domestic animal";
        byte[] bytes = Encoding.ASCII.GetBytes(content);
        // Write
        fileStream.Write(bytes, 0, bytes.Length);
        // Content again
        string content2 = "other text here";
        byte[] bytes2 = Encoding.ASCII.GetBytes(content2);
        // Write again
        fileStream.Write(bytes2, 0, bytes2.Length);

        // In case you forgot to close the file, either your text or information may not be saved properly in the file
        // or the operating system may still think that file was not closed, so in case next time when you want to delete the file
        // it may cause some issues or errors
        fileStream.Close();
        Console.WriteLine("dog.txt created");

        // File reading
        //FileStream fileStream2 = new(filePath, FileMode.OpenOrCreate, FileAccess.Read);
        //FileStream fileStream2 = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Read);
        //FileStream fileStream2 = File.OpenRead(filePath);
        //FileStream fileStream2 = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.Read);
        FileStream fileStream2 = fileInfo.OpenRead();
        byte[] byte3 = new byte[fileStream2.Length];
        fileStream2.Read(byte3, 0, (int)fileStream2.Length);
        string content3 = Encoding.ASCII.GetString(byte3);
        Console.WriteLine(content3);
        fileStream2.Close();

        Console.ReadKey();
    }
}