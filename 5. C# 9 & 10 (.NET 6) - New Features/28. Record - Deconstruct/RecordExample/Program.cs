public record Address(string City, string Country);
public record Person(string Name, int Age, Address PersonAddress);

class Program
{
    static void Main()
    {
        Person person = new("John", 20, new("London", "UK"));
        var (name, age, (city, country)) = person;    // This is called 'deconstruct', special method provided by record. Sequence is matter
        
        Console.WriteLine($"{person.Name}, {person.Age}, {person.PersonAddress.City}, {person.PersonAddress.Country}");
        Console.WriteLine($"{name}, {age}, {city}, {country}");

        (name, _, (city, country)) = person;    // If you want to skip copying certain property's value (in this example is age) you can use '_'
        Console.WriteLine($"{person.Name}, {person.PersonAddress.City}, {person.PersonAddress.Country}");
        Console.WriteLine($"{name}, {city}, {country}");

        Console.ReadKey();
    }
}