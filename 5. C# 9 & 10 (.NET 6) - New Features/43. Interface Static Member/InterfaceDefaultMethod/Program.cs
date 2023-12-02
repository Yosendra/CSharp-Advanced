
// Static method are allowed with concrete implement in interface

using InterfaceEnchancement;

namespace InterfaceEnchancement
{
    public interface IEmployee
    {
        public string Name { get; set; }

        // abstract method
        internal string GetNameInLowerCase();
        internal int GetNameLength();

        // static interface method
        public static string GetNameTitle()
        {
            return "Mr./Ms.";
        }

        internal string GetNameUpperCase()
        {
            return GetNameTitle() + Name.ToUpper();
        }
    }

    public class Manager : IEmployee
    {
        public string Name { get; set; }

        public double GetSalary() => 0;

        string IEmployee.GetNameInLowerCase()
        {
            return Name.ToLower();
        }

        public int GetNameLength()
        {
            return Name.Length;
        }
    }
}

class Program
{
    static void Main()
    { 
        Manager manager = new Manager();
        manager.Name = "William";

        Console.WriteLine(manager.Name);

        IEmployee iEmp = manager;
        Console.WriteLine(iEmp.GetNameUpperCase());
        Console.WriteLine(iEmp.GetNameUpperCase());
        Console.WriteLine(iEmp.GetNameLength());
        Console.WriteLine(manager.GetNameLength());

        // calling the static interface method
        Console.WriteLine(IEmployee.GetNameTitle());

        Console.ReadKey();
    }
}