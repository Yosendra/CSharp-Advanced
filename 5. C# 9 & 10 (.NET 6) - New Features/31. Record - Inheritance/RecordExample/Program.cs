public record Person(string? Name, 
    DateTime? DateOfBirth, 
    int? Age)
{
    public Person(string? name, DateTime? dateOfBirth) : this(name, dateOfBirth, null)
    {
        if (dateOfBirth is not null)
        {
            Age = Convert.ToInt32(DateTime.Now.Subtract(dateOfBirth.Value).TotalDays / 365.25);
        }
    }

    public Person() : this(null, null, null){}

    public string GetName()
    {
        return $"Ms./Mr. {Name}";
    }
}

// Record Inheritance. Record can inherit record, but it cannot inherit class
public record Employee(string? Name, DateTime? DateOfBirth, double? salary) : Person(Name, DateOfBirth);

class Program
{
    static void Main()
    {
        Employee employee = new("William", DateTime.Parse("1995-04-06"), 6000);
        Console.WriteLine(employee);

        Console.ReadKey();
    }
}