using System.Runtime.Serialization.Formatters.Binary;

// Add this in .csproj file
//
// <EnableUnsafeBinaryFormatterSerialization>true</EnableUnsafeBinaryFormatterSerialization>
//
// BinaryFormatter is obsolete and not recommended to be used, it just for learning sake

// This [Serializable] attribute need to be added in order to enable Country class to be serialized by BinaryFormatter object
[Serializable]
public class Country
{
    public short CountryId { get; set; }
    public string? CountryName { get; set; }
    public long Population { get; set; }
    public string? Region { get; set; }
}

class Program
{
    static void Main()
    {
        // Create country object
        Country country = new()
        {
            CountryId = 1,
            CountryName = "Rusia",
            Population = 145934000,
            Region = "Eastern Europe",
        };

        // Create the FileStream
        string filePath = @"c:\practice\rusia.txt";
        BinaryFormatter binaryFormatter;
        using (FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write))
        {
            // Create BinaryFormatter object
            binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, country);
            Console.WriteLine("Serialized");
        }

        // Code for Deserialize
        FileStream fileStream2 = new(filePath, FileMode.Open, FileAccess.Read);
        // Need to be type casted
        var country_from_file = (Country)binaryFormatter.Deserialize(fileStream2);
        Console.WriteLine("\nData after deserialization:");
        Console.WriteLine($"CountryId : {country_from_file.CountryId}");
        Console.WriteLine($"CountryName : {country_from_file.CountryName}");
        Console.WriteLine($"Population : {country_from_file.Population}");
        Console.WriteLine($"Region : {country_from_file.Region}");

        Console.ReadKey();
    }
}