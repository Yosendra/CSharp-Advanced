public record Address(string City, string Country);
public record Person(string Name, int Age, Address PersonAddress)
{
    public int Property1 { get; set; }
};

class Program
{
    static void Main()
    {
        Person person1 = new("John", 20, new("London", "UK"));
        Person person2 = new Person("Sylvia", 30, new Address("Manhattan", "USA"));
        Person person3 = new Person("Sylvia", 30, new Address("Manhattan", "USA"));

        person1.Property1 = 10;

        Console.WriteLine($"{person1.Name}, {person1.Age}, {person1.PersonAddress.City}");
        Console.WriteLine($"{person2.Name}, {person2.Age}, {person2.PersonAddress.City}");

        // In record, it compare the property's value not the memory address like class
        // If both are classes, it will return 'false'
        Console.WriteLine($"Is person2 and person3 same? : {person2 == person3}");      // true

        Console.ReadKey();
    }
}