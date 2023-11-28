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
        // This here will be complicated. Full of if statement. Too bulky, fat, lengthy
        if (person.GetType() == typeof(Employee))
        {
            var emp = (Employee)person;
            return $"{person.Name}, {person.Age}, {person.Gender}, {emp.Salary}";
        }
        else if (person.GetType() == typeof(Customer))
        {
            var cust = (Customer)person;
            return $"{person.Name}, {person.Age}, {person.Gender}, {cust.CustomerBalance}";
        }
        else if (person.GetType() == typeof(Supplier))
        {
            var sup = (Supplier)person;
            return $"{person.Name}, {person.Age}, {person.Gender}, {sup.SupplierBalance}";
        }
        else
        {
            return $"{person.Name}, {person.Age}, {person.Gender}";
        }
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

        Console.WriteLine(Descripter.GetDescription(customer));

        Console.ReadKey();
    }
}