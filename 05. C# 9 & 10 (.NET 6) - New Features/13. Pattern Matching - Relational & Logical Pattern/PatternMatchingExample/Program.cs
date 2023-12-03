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
        // pay attention to the 'is', and after that. We use relational and logical operator in the switch pattern
        // also we do not repeat p.Age many times

        string result = person switch
        {
            // equal to : p.Age < 20 && p.age >= 13
            Person p when p.Age is < 20 and >= 13
                => $"{p.Name} is a teenager",

            // equal to : p.age < 13, when there is only one condition, you can remove the 'is' operator
            Person p when p.Age < 13
                => $"{p.Name} is a child",

            // equal to : p.Age >= 20 && p.age < 60
            Person p when p.Age is >= 20 and < 60
                => $"{p.Name} is an adult",

            // equal to : p.Age >= 60
            Person p when p.Age is >= 60 and not (100 or 200)
                => $"{p.Name} is a senior citizen",

            // equal to : p.Age == 100 || p.Age == 200
            Person p when p.Age is 100 or 200
                => $"{p.Name} is a centenarian",

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
            Age = 100,
            CustomerBalance = 1000,
        };

        Console.WriteLine(Descripter.GetDescription(customer));
        Console.WriteLine(Descripter.GetDescriptionAge(customer));

        Console.ReadKey();
    }
}