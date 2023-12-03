public record Address(string City, string Country);
public record Person(string Name, Address PersonAddress)
{
    public int Age { get; set; }
};

class Program
{
    static void Main()
    {
        Person person1 = new("John", new("London", "UK"));
        Person person2 = new Person("Sylvia", new Address("Manhattan", "USA"));
        
        Person person3 = person2;   // This is reference copy
        person2.Age = 666;    // try to assign value to mutable property in person 2

        // Age's value in person3 is also changed because reference copy of object
        Console.WriteLine($"{person2.Name}, {person2.Age}, {person2.PersonAddress.City}");
        Console.WriteLine($"{person3.Name}, {person3.Age}, {person3.PersonAddress.City}");

        Person person4 = person2 with { };  // This is shallow copy, it creates new Person record object with same value as person2
        person2.Age = 27;   // try to assign value to mutable property in person2

        // Age's value in person4 is not affected due to change Age's value in person2 
        Console.WriteLine("\n");
        Console.WriteLine($"{person2.Name}, {person2.Age}, {person2.PersonAddress.City}");
        Console.WriteLine($"{person4.Name}, {person4.Age}, {person4.PersonAddress.City}");

        Console.ReadKey();

        // This copy rule is applicable only on value-type datatype (struct, enum, etc)
        // if the field is an reference type, the memory will be copied not creating a new object. This is a shallow copy.
    }
}