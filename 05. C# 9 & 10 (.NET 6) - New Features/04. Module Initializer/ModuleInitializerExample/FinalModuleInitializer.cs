using System.Runtime.CompilerServices;

namespace Initializer
{
    internal class FinalModuleInitializer
    {
        // If we want to adjust the sequence of ModuleInitializer we want to run first, we can encapsulate both the static method
        // in one ModuleInitializer like below. Of course with 'ModuleInitializer' not implemented on those both static method
        // so it will only one 'ModuleInitializer' implemented here

        [ModuleInitializer]
        public static void FinalInitializer()
        {
            Initializer2.Initialize2();
            Initializer1.Initialize1();
        }
    }
}
