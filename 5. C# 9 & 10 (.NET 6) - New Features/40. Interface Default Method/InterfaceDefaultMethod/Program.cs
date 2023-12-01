
// Intrface Default Method is method in interface with concrete implementation

using InterfaceEnchancement;

namespace InterfaceEnchancement
{
    public interface IEmployee
    {
        public string Name { get; set; }

        // Default Interface Method | Virtual Extension Method
        public string GetNameUpperCase()
        {
            return Name.ToUpper();
        }
    }

    public class Manager : IEmployee
    {
        public string Name { get; set; }

        public double GetSalary() => 0;
    }

    public class Clerk : IEmployee
    {
        public string Name { get; set; }
    }
}

class Program
{
    static void Main()
    { 
        Manager manager = new Manager();
        manager.Name = "William";

        Console.WriteLine(manager.Name);

        // Calling the method that we inherited from interface immediately is not working.
        // Because '.GetNameUpperCase()' is not defined in 'Manager' class
        // We have to type-cast it to its interface type

        //Console.WriteLine(manager.GetNameUpperCase());

        IEmployee iEmp = manager;
        Console.WriteLine(iEmp.GetNameUpperCase());
        Console.WriteLine(iEmp.GetType());  // the object is still 'Manager', but the public function we can access only according to its interface

        Console.ReadKey();
    }
}