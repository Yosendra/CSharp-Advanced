// Record => it equals to create a class but each property will have { get; init; } method
// And also constructor with argument correspond to its definition
// The goal of record is to create a reference-type with immutable properties by default.
// Look code below

// Define the 'Person' record
public record Person(string Name, int Age);

class Program
{
    static void Main()
    {
        // Intantiate the 'Person' record
        Person person1 = new("John", 20);
        Person person2 = new Person("Sylvia", 30);

        //person1.Age = 10; // This will be an error

        Console.WriteLine($"{person1.Name}, {person1.Age}");
        Console.WriteLine($"{person2.Name}, {person2.Age}");

        Console.ReadKey();
    }
}