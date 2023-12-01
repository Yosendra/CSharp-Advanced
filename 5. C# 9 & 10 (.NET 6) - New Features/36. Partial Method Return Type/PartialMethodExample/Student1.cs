namespace PartialMethodExample
{
    // Partial class in the same namespace
    // Will be combined with the other same partial class when compilation

    // Student1.cs
    partial class Student
    {
        // Here we set field in Student1.cs, then we set the property in Student2.cs
        private int _id;

        // partial method declaration in the past, before C# 9
        partial void DoSomething(); // by default private, cannot have 'out' parameter, return type should be void

        // This is the new feature
        public partial int GetStudentId();  // at least should have any implementation, we try to make the implementation in the other part
    }
}
