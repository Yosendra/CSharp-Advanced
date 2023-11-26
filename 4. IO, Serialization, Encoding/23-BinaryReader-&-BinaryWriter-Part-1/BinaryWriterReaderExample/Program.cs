class Program
{
    static void Main()
    {
        short countryId = 1;
        string countryName = "France";
        long population = 65273511;
        string region = "Western Europe";
        string filePath = @"c:\practice\france.txt";
        
        // BinaryWriter write binary data format to a file
        FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write);
        using (BinaryWriter binaryWriter = new(fileStream))
        {
            binaryWriter.Write(countryId);
            binaryWriter.Write(countryName);
            binaryWriter.Write(population);
            binaryWriter.Write(region);
        }
        Console.WriteLine("france.txt created");

        Console.ReadKey();
    }
}