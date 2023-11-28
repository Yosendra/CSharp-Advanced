// class_name variable_name = new();    equivalent to "new class_name()"
// It can't be used with 'var' keyword  ->  var employee = new();  //error

class Employee 
{ 
    public int x = 19;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public AddressDetails? PersonAddressDetails { get; set; }

    public Employee(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

class AddressDetails
{
    public string? City { get; set; }
    public int? ZipCode { get; set; }
}

class EmployeeBusinessLogic
{
    public Employee? GetEmployee()
    {
        //return new Employee();
        // This is allowed by looking the return type of the method
        return new("John", "Doe");  // equivalent to 'return new Employee("John", "Doe");'
    }
}

class DataPrinter
{
    public static void PrintEmployee(Employee e)
    {
        if (e != null)
        {
            Console.WriteLine($"{e.FirstName} {e.LastName}");
        }
    }
}

class Program
{
    public static void Main()
    {
        EmployeeBusinessLogic employeeBusinessLogic = new EmployeeBusinessLogic();

        Employee? employee = employeeBusinessLogic.GetEmployee();
        bool isValid = employee != null;

        if (isValid)
        {
            Console.WriteLine(employee!.FirstName.ToUpper());
            Console.WriteLine(employee!.LastName.ToUpper());
            Console.WriteLine(employee!.PersonAddressDetails?.City);
            Console.WriteLine(employee!.PersonAddressDetails?.ZipCode);
        }
        else
        {
            Console.WriteLine("employee is null");
        }

        // This possible by looking the parameter type of .PrintEmployee()
        DataPrinter.PrintEmployee(new("Jin", "Jun"));

        Console.ReadKey();
    }
}