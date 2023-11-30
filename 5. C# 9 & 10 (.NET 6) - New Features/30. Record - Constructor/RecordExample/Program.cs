public record Person(string? Name, DateTime? DateOfBirth, int? Age)
{
    // Implementing user defined constructor in record, we pass null for Age first
    public Person(string name, DateTime? dateOfBirth) : this(name, dateOfBirth, null)   // call the compiler generated constructor
    {
        // then we override the Age with result of our calculation
        if (dateOfBirth is not null)
        {
            Age = Convert.ToInt32(DateTime.Now.Subtract(dateOfBirth.Value).TotalDays / 365.25);
        }
    }

    // This parameterless constructor in record
    public Person() : this(null, null, null)
    {
    }

    // You can define method in a record, but it is not advisable
    public string GetName()
    {
        return $"Ms./Mr. {Name}";
    }
}
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
        Person person = new("John", DateTime.Parse("2001-06-04"));
        
        Console.WriteLine($"{person.Age}");
        Console.WriteLine($"{person.Name}");
        
        Console.ReadKey();
    }
}