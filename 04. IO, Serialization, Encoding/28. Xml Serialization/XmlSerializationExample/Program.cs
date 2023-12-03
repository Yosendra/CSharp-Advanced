using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// This is using .NET Framework 4.8

namespace XmlSerializationExample
{
    [Serializable]
    public class Continent
    {
        public string ContinentName { get; set; }
        public List<Country> Countries { get; set; }
    }

    [Serializable]
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var continents = new List<Continent>();
            continents.Add(new Continent()
            {
                ContinentName = "Africa",
                Countries = new List<Country>() { 
                    new Country() { CountryId = 1, CountryName = "Sudan"},
                    new Country() { CountryId = 2, CountryName = "Libya"},
                    new Country() { CountryId = 3, CountryName = "South Africa"},
                }
            });

            continents.Add(new Continent()
            {
                ContinentName = "Asia",
                Countries = new List<Country>() {
                    new Country() { CountryId = 4, CountryName = "Rusia"},
                    new Country() { CountryId = 5, CountryName = "China"},
                    new Country() { CountryId = 6, CountryName = "India"},
                }
            });

            continents.Add(new Continent()
            {
                ContinentName = "Europe",
                Countries = new List<Country>() { 
                    new Country() { CountryId = 7, CountryName = "Rusia"},
                    new Country() { CountryId = 8, CountryName = "Ukraine"},
                    new Country() { CountryId = 9, CountryName = "France"},
                }
            });
            
            continents.Add(new Continent()
            {
                ContinentName = "North America",
                Countries = new List<Country>() { 
                    new Country() { CountryId = 10, CountryName = "Canada"},
                    new Country() { CountryId = 11, CountryName = "United States"},
                    new Country() { CountryId = 12, CountryName = "Mexico"},
                }
            });
            
            continents.Add(new Continent()
            {
                ContinentName = "South America",
                Countries = new List<Country>() { 
                    new Country() { CountryId = 13, CountryName = "Brazil"},
                    new Country() { CountryId = 14, CountryName = "Argentina"},
                    new Country() { CountryId = 15, CountryName = "Peru"},
                }
            });

            var xmlSerializer = new XmlSerializer(typeof(List<Continent>));

            // Serialize
            string filePath = @"c:\practice\continents.xml";
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, continents);
                Console.WriteLine("continents.xml created");
            }

            // Deserialize
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var continents_from_file = xmlSerializer.Deserialize(fileStream) as List<Continent>;
                Console.WriteLine("\nAfter Deserialize:");
                foreach (var continent in continents_from_file)
                {
                    Console.WriteLine($"{continent.ContinentName}");

                    foreach (var country in continent.Countries)
                    {
                        Console.WriteLine($"\t{country.CountryName}");
                    }

                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
