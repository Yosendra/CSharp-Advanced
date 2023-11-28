enum MaritalStatus
{
    Unmarried, Married
}

class Person
{
    public string? Name { get; set; }
    public int? Age { get; set; }
    public string? Gender { get; set; }
    public MaritalStatus PersonMaritalStatus { get; set; }
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
        // Property pattern

        string result = person switch
        {
            Person { Age: < 20 and >= 13 }
                p => $"{p.Name} is a teenager",

            Person { Age: < 13 }
                p => $"{p.Name} is a child",

            Person { Age: >= 20 and < 60 }
                p => $"{p.Name} is an adult",

            Person { Age: >= 60 and not (100 or 200) }
                p => $"{p.Name} is a senior citizen",

            Person { Age: 100 or 200 }
                p => $"{p.Name} is a centenarian",

            _
                => $"{person.Name} is a person"
        };

        return result;
    }

    public static string GetDescriptionMaritalStatus(Person person)
    {
        // Tupple Pattern
        return (person, person.Gender, person.Age, person.PersonMaritalStatus) switch
        {
            (Person, "Female", _, MaritalStatus.Unmarried) 
                => $"Miss. {person.Name}",

            (Person, "Female", _, MaritalStatus.Married)
                => $"Mrs. {person.Name}",

            (Person, "Male", < 18, _)
                => $"Master {person.Name}",

            (Person, "Male", >= 18, _)
                => $"Mr. {person.Name}",

            (Person, not("Female" or "Male"), _, _)
                => $"Mx. {person.Name}",

            _ => $"{person.Name}"
        };
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
            PersonMaritalStatus = MaritalStatus.Married,
        };

        Customer customer = new()
        {
            Name = "Smith",
            Gender = "Male",
            Age = 100,
            CustomerBalance = 1000,
            PersonMaritalStatus = MaritalStatus.Unmarried,
        };

        Console.WriteLine(Descripter.GetDescription(customer));
        Console.WriteLine(Descripter.GetDescriptionAge(customer));
        Console.WriteLine(Descripter.GetDescriptionMaritalStatus(customer));

        Console.ReadKey();
    }
}