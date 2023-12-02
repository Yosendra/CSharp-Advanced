
// Intrface method can have any access modifier including private, internal, protected, private protected, public

using InterfaceEnchancement;

namespace InterfaceEnchancement
{
    public interface IEmployee
    {
        public string Name { get; set; }

        internal string GetNameUpperCase()
        {
            return Name.ToUpper();
        }

        // abstract method
        internal string GetNameInLowerCase();
        internal int GetNameLength();
    }

    public class Manager : IEmployee
    {
        public string Name { get; set; }

        public double GetSalary() => 0;

        // Option 1: You can explicitly implement non-public abstract interface method

        // Beside 'public' modifier, we can override the interface method immediately
        // but now it is other than 'public' ('internal' in this case)
        // so we need explicitly mention the the interface the method belong ('IEmployee')
        string IEmployee.GetNameInLowerCase()
        {
            return Name.ToLower();
        }

        // Option 2: You can convert the non-public abstract interface method as public
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

        // for the option 1, the invocation only when we use the interface type
        Console.WriteLine(iEmp.GetNameUpperCase());

        // for the option 2, the invocation is enable either when we use the interface type or class type
        Console.WriteLine(iEmp.GetNameLength());
        Console.WriteLine(manager.GetNameLength());

        Console.ReadKey();
    }
}