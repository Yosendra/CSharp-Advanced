using System.Runtime.CompilerServices;

// 'ModuleInitializer' will be executed when startup, means it will be executed before application running Main() function

namespace Initializer
{
    internal class Initializer1
    {
        // The method should be public or internal, static, void, and should not have parameter
        //[ModuleInitializer]
        public static void Initialize1()
        {
            Console.WriteLine("From Initialize1");
        }
    }
}
