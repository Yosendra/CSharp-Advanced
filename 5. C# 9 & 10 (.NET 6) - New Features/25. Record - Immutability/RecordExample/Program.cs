public record Address(string City);

// We can make property mutable in record in this way
public record Person(string Name, int Age, Address PersonAddress)
{
    // here are mutable property in record
    public int Property1 { get; set; }
};

class Program
{
    static void Main()
    {
        // When object initialization
        Person person1 = new("John", 20, new("London"));
        Person person2 = new Person("Sylvia", 30, new Address("Manhattan"));

        // We can assign to a record's property
        person1.Property1 = 10;

        Console.WriteLine($"{person1.Name}, {person1.Age}, {person1.PersonAddress.City}");
        Console.WriteLine($"{person2.Name}, {person2.Age}, {person2.PersonAddress.City}");

        Console.ReadKey();
    }
}