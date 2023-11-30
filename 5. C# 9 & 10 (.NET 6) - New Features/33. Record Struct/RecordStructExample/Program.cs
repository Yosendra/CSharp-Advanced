using System.Reflection;

namespace record_struct_example
{
    // Remember initially record is just a 'class'? now it become 'struct' now
    public record struct Person(string? Name, int? Age);
    //public readonly record struct Person(string? Name, int? Age);

    class Program
    {
        static void Main()
        {
            // person here is struct object, not class object.
            // Keyword new here just dummy in order to initialize struct object.
            Person person1 = new Person("Jason", 30);
            Console.WriteLine(person1);

            // This will be treated as value-type copy
            Person person2 = person1;

            // Here Age is mutable. To make it immutable, we can add readonly keyword struct record Person definition
            person2.Age = 31; // will not affect other struct object

            // Age value will be different
            Console.WriteLine(person1.Age);
            Console.WriteLine(person2.Age);

            Console.ReadKey();
        }
    }
}