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

    public override string ToString()
    {
        return $"Name is {Name}";
    }
}

public record Employee(string? Name, DateTime? DateOfBirth, double? salary) : Person(Name, DateOfBirth)
{
    // 'sealed' kerword will guarantee that this '.ToString()' method cannot be overriden by child record
    public sealed override string ToString()
    {
        return $"Salary is {salary}, {base.ToString()}";
    }
}

class Program
{
    static void Main()
    {
        Employee employee = new("William", DateTime.Parse("1995-04-06"), 6000);
        Console.WriteLine(employee);

        Console.ReadKey();
    }
}