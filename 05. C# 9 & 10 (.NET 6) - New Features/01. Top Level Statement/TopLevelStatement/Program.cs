// There is no need to encapsulate the statements inside Main() function anymore

// Warning
// 1. We cannot define class or namespace above the statement
// 2. Only one file can have top-level statement in one project
// 3. Cannot use local variable or local function declared in a top-level statement
// 4. Top-level statements automatically will be encapsulated in Main() function of Program class at compilation time

string user = "Yosi";
Console.WriteLine("Hello, World! " + user);
Console.ReadKey();

namespace Namespace1
{
    class MyClass
    {
        // cannot access local variable in top-level statement
        // string name = user;
    }
}

//class Program {}  // This will be error too if we use top-level statement