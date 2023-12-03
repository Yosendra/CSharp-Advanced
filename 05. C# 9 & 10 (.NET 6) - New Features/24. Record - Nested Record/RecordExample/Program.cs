public record Address(string City);
// We set Address record as the property, so it nested in Person record
public record Person(string Name, int Age, Address PersonAddress);

class Program
{
    static void Main()
    {
        // When object initialization
        Person person1 = new("John", 20, new("London"));
        Person person2 = new Person("Sylvia", 30, new Address("Manhattan"));

        Console.WriteLine($"{person1.Name}, {person1.Age}, {person1.PersonAddress.City}");
        Console.WriteLine($"{person2.Name}, {person2.Age}, {person2.PersonAddress.City}");

        Console.ReadKey();
    }
}