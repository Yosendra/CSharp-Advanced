public record Person(string Name, int Age, Address PersonAddress);
public record Address(string City, string Country)
{
    public override string ToString()   // We are overriding the '.ToString()' method
    {
        return $"City is {City} in {Country}";
    }
}

class Program
{
    static void Main()
    {
        Person person = new("John", 20, new("London", "UK"));
        
        Console.WriteLine($"{person}");
        Console.WriteLine($"{person.PersonAddress}");
        
        Console.ReadKey();
    }
}