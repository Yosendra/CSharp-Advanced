using System.Security.Cryptography.X509Certificates;

class Employee 
{ 
    public int x = 19;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public AddressDetails? PersonAddressDetails { get; set; }

    public Employee()
    {
        FirstName = "default string";
        LastName = "default string";
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
        //return null;
        return new Employee();
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
            // Here compiler give warning that employee may be null,
            // so in order to insist the compiler that employee is not null
            // we give 'Null Forgiving Operator (!)' as suffix of 'employee' variable
            Console.WriteLine(employee!.FirstName.ToUpper());
            Console.WriteLine(employee!.LastName.ToUpper());
            Console.WriteLine(employee!.PersonAddressDetails?.City);     // It will be equal to null if PersonAddressDetails is null 
            Console.WriteLine(employee!.PersonAddressDetails?.ZipCode);  // It will be equal to null if PersonAddressDetails is null
            // Use this wisely if we sure it will be not null
        }
        else
        {
            Console.WriteLine("employee is null");
        }
        Console.ReadKey();
    }
}