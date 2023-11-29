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
    public BirthDateInfo? BirthDate { get; set; }
}

public class BirthDateInfo
{
    public DateTime DateOfBirth { get; set; }
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
        // Nested Property Pattern : we are matching the property inside property. Look at the BirthDate checking
        return person switch
        {
            // Alternative 1 (Nested Property Pattern): use colon to access inner property
            //Person { Gender:"Female", PersonMaritalStatus: MaritalStatus.Unmarried, BirthDate: { DateOfBirth: { Year: > 2000 } } }

            // Alternative 2 (Extended Property Pattern): use dot to access inner property
            Person { Gender:"Female", PersonMaritalStatus: MaritalStatus.Unmarried, BirthDate.DateOfBirth.Year: > 2000 } 
                => $"Miss. {person.Name}",

            Person { Gender: "Female", PersonMaritalStatus: MaritalStatus.Married }
                => $"Mrs. {person.Name}",

            Person { Gender: "Male", Age: < 18 }
                => $"Master {person.Name}",

            Person { Gender: "Male", Age: >= 18 }
                => $"Mr. {person.Name}",

            Person { Gender: not("Female" or "Male") }
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
            BirthDate = new() { DateOfBirth = DateTime.Parse("2002-01-1") },
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
        Console.WriteLine(Descripter.GetDescriptionMaritalStatus(manager));

        Console.ReadKey();
    }
}