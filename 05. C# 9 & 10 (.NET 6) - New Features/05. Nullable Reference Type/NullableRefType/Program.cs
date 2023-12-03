class Employee { public int x = 19; }

// Employee  => Non-nullable reference type (null value is not accepted)
// Employee? => Nullable reference type (null value is accepted)
// By default all classes and interfaces are 'non-nullable reference type' to convert them as 'nullable reference type', suffix a question mark (?)

class EmployeeBusinessLogic
{
    public Employee? GetEmployee()
    {
        return null;
    }
}

class Program
{
    public static void Main()
    {
        EmployeeBusinessLogic employeeBusinessLogic = new EmployeeBusinessLogic();

        Employee? employee = employeeBusinessLogic.GetEmployee();
        if (employee != null)
        {
            Console.WriteLine(employee.x);
        }
        else
        {
            Console.WriteLine("employee is null");
        }
        Console.ReadKey();
    }
}