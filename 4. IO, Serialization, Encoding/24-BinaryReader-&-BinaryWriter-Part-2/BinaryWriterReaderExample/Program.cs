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

        // BinaryReader reads binary data format from a file
        FileStream fileStream2 = new(filePath, FileMode.Open, FileAccess.Read);
        using (BinaryReader binaryReader = new(fileStream2))
        {
            // The method invoked by binaryReader is matter because C# don't know what data type is saved in the file
            var countryId_from_file = binaryReader.ReadInt16();
            var countryName_from_file = binaryReader.ReadString();
            var population_from_file = binaryReader.ReadInt64();
            var region_from_file = binaryReader.ReadString();

            Console.WriteLine($"CountryId : {countryId_from_file}");
            Console.WriteLine($"countryName : {countryName_from_file}");
            Console.WriteLine($"population : {population_from_file}");
            Console.WriteLine($"region : {region_from_file}");
        }

        Console.ReadKey();
    }
}