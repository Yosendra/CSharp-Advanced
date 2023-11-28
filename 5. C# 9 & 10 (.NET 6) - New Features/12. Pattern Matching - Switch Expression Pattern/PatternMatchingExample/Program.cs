class Person
{
    public string? Name { get; set; }
    public int? Age { get; set; }
    public string? Gender { get; set; }
}

class Employee : Person
{
    public double? Salary { get; set; }
}

class Customer : Person
{
    public double? CustomerBalance { get; set; }
}

class Supplier : Person
{
    public double? SupplierBalance { get; set; }
}

class Manager : Employee
{
    
}

class Descripter
{
    public static string GetDescription(Person person)
    {
        // 'switch-case pattern' here used to check person type also cast it to another type
        switch (person)
        {
            case Employee employee:
                return $"{person.Name}, {person.Age}, {person.Gender}, {employee.Salary}";

            case Customer customer:
                return $"{person.Name}, {person.Age}, {person.Gender}, {customer.CustomerBalance}";

            case Supplier supplier:
                return $"{person.Name}, {person.Age}, {person.Gender}, {supplier.SupplierBalance}";

            default:
                return $"{person.Name}, {person.Age}, {person.Gender}";
        }
    }

    public static string GetDescriptionAge(Person person)
    {
        // 'switch expression pattern'

        string result = person switch
        {
            Person p when (p.Age < 20 && p.Age >= 13)
                => $"{p.Name} is a teenager",
            Person p when (p.Age < 13)
                => $"{p.Name} is a child",
            Person p when (p.Age >= 20 && p.Age < 60)
                => $"{p.Name} is an adult",
            Person p when (p.Age >= 60)
                => $"{p.Name} is a senior citizen",
            _
                => $"{person.Name} is a person"
        };

        return result;
    }
}

class Program
{
    static void Main()
    {
        Manager manager = new()
        {
            Name = "John",
            Gender = "Male",
            Age = 20,
            Salary = 3000,
        };

        Customer customer = new()
        {
            Name = "Smith",
            Gender = "Male",
            Age = 30,
            CustomerBalance = 1000,
        };

        Console.WriteLine(Descripter.GetDescription(manager));
        Console.WriteLine(Descripter.GetDescriptionAge(manager));

        Console.ReadKey();
    }
}